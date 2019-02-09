using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Models;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Models.Paypal;
using BlueTapeCrew.Web.Repositories.Interfaces;
using BlueTapeCrew.Web.Services.Interfaces;
using BlueTapeCrew.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayPal;

namespace BlueTapeCrew.Web.Controllers
{
    [RequireHttps]
    public class CheckoutController : Controller
    {
        private readonly bool _isSandbox;
        private readonly ICartService _cartService;
        private readonly IInvoiceService _invoiceService;
        private readonly IOrderService _orderService;
        private readonly IPaypalService _paypalService;
        private readonly ISiteSettingsService _siteSettingsService;
        private readonly IEmailService _emailService;
        private readonly ISessionService _sessionService;
        private readonly IGuestUserRepository _guestUserRepository;
        //private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutController(
            ICartService cartService,
            IEmailService emailService,
            IOrderService orderService,
            IPaypalService paypalService,
            ISiteSettingsService siteSettingsService,
            IInvoiceService invoiceService, IHttpContextAccessor context,
            //UserManager<ApplicationUser> userManager, 
            ISessionService sessionService,
            IGuestUserRepository guestUserRepository)
        {
            _cartService = cartService;
            _orderService = orderService;
            _invoiceService = invoiceService;
            //_userManager = userManager;
            _sessionService = sessionService;
            _guestUserRepository = guestUserRepository;
            _paypalService = paypalService;
            _siteSettingsService = siteSettingsService;
            _emailService = emailService;
#if DEBUG
            _isSandbox = true;
#endif
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var cart = await _cartService.GetCartViewModel(_sessionService.GetId());
            if (cart == null) return RedirectToAction("EmptyCart");
            //var user = new ApplicationUser();
            //if (!string.IsNullOrEmpty(User.Identity.Name))
            //{
            //    user = await _userManager.FindByNameAsync(User.Identity.Name);
            //}
            var model = new CheckoutViewModel(/*user,*/ cart/*, user*/);
            ViewBag.ReturnUrl = HttpContext.Request.GetDisplayUrl();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(CheckoutViewModel model, string itemamt, string shipping, string amt)
        {
            try
            {
                string cartId = string.Empty;
                if (ModelState.IsValid)
                {
                    cartId = _sessionService.GetId();
                    if (User.Identity.IsAuthenticated)
                    {
                        //var user = await _userManager.FindByNameAsync(User.Identity.Name);
                        //user.Update(model);
                        //await _userManager.UpdateAsync(user);
                    }
                    else
                    {
                        var guestUser = new GuestUser
                        {
                            SessionId = cartId.Replace("-", ""),
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Address = model.Address,
                            City = model.City,
                            State = model.State,
                            PostalCode = model.Zip,
                            PhoneNumber = model.Phone,
                            Email = model.Email,
                        };
                        
                        await
                            _guestUserRepository.CreateGuestUser(guestUser);
                    }

                    var settings = await _siteSettingsService.Get();
                    var cart = await _cartService.GetCartViewModel(cartId);

                    //todo: impliment token store and get token if not expired
                    var accessToken = string.Empty;
                    var invoice = await _invoiceService.Create(cartId);


                    var uri = new Uri(HttpContext.Request.GetDisplayUrl());
                    var paymentRequest = new PaymentRequest(uri, settings, cart.Items.ToList(), invoice.Id, accessToken, _isSandbox);
                    var redirectUrl = await _paypalService.PaywithPaypal(paymentRequest);
                    if (!string.IsNullOrEmpty(redirectUrl)) Response.Redirect(redirectUrl);

                }
                ViewBag.Errors = true;
                model.Cart = await _cartService.GetCartViewModel(cartId);
                return View(model);

            }
            catch (PaymentsException ex)
            {
                return Content(ex.Response);
            }
        }

        public ViewResult EmptyCart()
        {
            return View();
        }

        [Route("checkoutreview")]
        public async Task<ActionResult> CheckoutReview(string paymentId, string token, string payerId, string cancel = "false")
        {
            var cartId = _sessionService.GetId();
            if (cancel == "true") return RedirectToAction("CheckoutCancel");
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(payerId))
                return RedirectToAction("Index", "Checkout");

            ViewBag.Token = token;
            ViewBag.PayerId = payerId;
            ViewBag.PaymentId = paymentId;
            var model = new CheckoutViewModel();
            if (User.Identity.IsAuthenticated)
            {
                //var user = await _userManager.FindByNameAsync(User.Identity.Name);
                //model.FirstName = user.FirstName;
                //model.LastName = user.LastName;
                //model.Address = user.Address;
                //model.City = user.City;
                //model.State = user.State;
                //model.Zip = user.PostalCode;
            }
            else
            {
                var user = await _guestUserRepository.GetGuestUser(cartId);
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Email = user.Email;
                model.Phone = user.PhoneNumber;
                model.Address = user.Address;
                model.City = user.City;
                model.State = user.State;
                model.Zip = user.PostalCode;
            }
            model.Cart = await _cartService.GetCartViewModel(cartId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Complete(CompletePaymentRequest completePaymentRequest)
        {
            var cartId = _sessionService.GetId();
            try
            {
                string clientId;
                string clientSecret;
                var settings = await _siteSettingsService.Get();

                if (_isSandbox)
                {
                    clientId = settings.PaypalSandBoxClientId;
                    clientSecret = settings.PaypalSandBoxSecret;
                }
                else
                {
                    clientId = settings.PaypalClientId;
                    clientSecret = settings.PaypalClientSecret;
                }
                completePaymentRequest.Token = await _paypalService.GetAccessToken(_isSandbox);
                var completedPayment = _paypalService.CompletePayment(completePaymentRequest);
                ViewBag.PaymentConfirmation = completedPayment.id;
            }
            catch (PaymentsException ex)
            {
                return Content(ex.Response);
            }



            var cartView = await _cartService.Get(cartId);
            var cartViews = cartView.ToList();
            var subtotal = cartViews.Sum(x => x.SubTotal);
            var shipping = 0;
            if (subtotal < 50)
            {
                shipping = 6;
            }

            var total = subtotal + shipping;

            var order = new Order
            {
                IpAddress = Request.Host.Value,
                SessionId = cartId,
                Shipping = shipping,
                SubTotal = subtotal,
                Total = total,
                DateCreated = DateTime.UtcNow
            };

            if (User.Identity.IsAuthenticated)
            {
                //var user = await _userManager.FindByNameAsync(User.Identity.Name);
                //if (user != null)
                //{
                //    order.FirstName = user.FirstName;
                //    order.LastName = user.LastName;
                //    order.Address = user.Address;
                //    order.City = user.City;
                //    order.State = user.State;
                //    order.Zip = user.PostalCode;
                //}
            }
            else
            {
                var user = await _guestUserRepository.GetGuestUser(cartId);
                order.Email = user.Email;
                order.FirstName = user.FirstName;
                order.LastName = user.LastName;
                order.Address = user.Address;
                order.City = user.City;
                order.State = user.State;
                order.Zip = user.PostalCode;
                order.Phone = user.PhoneNumber;
            }

            order.OrderItems = new List<OrderItem>();
            foreach (var item in cartViews.ToList())
            {
                order.OrderItems.Add(new OrderItem
                {
                    Description = item.ProductName + " " + item.StyleText,
                    Price = item.Price,
                    SubTotal = item.SubTotal,
                    Quantity = item.Quantity
                });
            }
            await _orderService.AddOrder(order);
            await _cartService.EmptyCart(cartId);
            return RedirectToAction("OrderConfirmation", "Checkout", new { id = order.Id });
        }

        public ActionResult CheckoutCancel()
        {
            return View();
        }

        public async Task<ActionResult> OrderConfirmation(int id)
        {
            var order = await _orderService.GetOrder(id);
            var emailRequest = await GetSmtpRequest(order);
            await _emailService.SendEmail(emailRequest);
            return View(order);
        }

        private async Task<SmtpRequest> GetSmtpRequest(Order order)
        {
            var settings = await _siteSettingsService.Get();
            var textBody = EmailTemplates.GetOrderConfirmationTextBody(order, User.Identity.IsAuthenticated);
            var htmlBody = EmailTemplates.GetOrderConfirmationHtmlBody(order);
            return new SmtpRequest(settings, htmlBody, textBody, order.Email);
        }

        public async Task<ActionResult> OrderError()
        {
            var cartId = _sessionService.GetId();
            ViewBag.Message = "Your order was not placed, there was an issue.  Please contact us.";
            return View(await _cartService.GetCartViewModel(cartId));
        }
    }
}