using System.Linq;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlueTapeCrew.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ISiteSettingsService _siteSettingsService;
        private readonly ISessionService _sessionService;

        public CartController(ICartService cartService, ISiteSettingsService siteSettingsService, ISessionService sessionService)
        {
            _cartService = cartService;
            _siteSettingsService = siteSettingsService;
            _sessionService = sessionService;
        }

        [Route("cart")]
        public async Task<ActionResult> Details()
        {
            var cart = await _cartService.Get(_sessionService.GetId());
            var settings = await _siteSettingsService.Get();

            var subTotal = cart.Sum(x => x.SubTotal);
            ViewBag.SubTotal = $"{subTotal:n2}";
            if (subTotal > settings.FreeShippingThreshold)
            {
                ViewBag.Shipping = "0.00";
                ViewBag.Total = ViewBag.SubTotal;
            }
            else
            {
                ViewBag.Shipping = $"{settings.FlatShippingRate:n2}";
                ViewBag.Total = $"{subTotal + 6:n2}";
            }
            return View(cart);
        }

        [Route("cart/index")]
        public async Task<PartialViewResult> Index()
        {
            var model = await _cartService.GetCartViewModel(_sessionService.GetId());
            return PartialView(model);
        }

        [HttpPost]
        [Route("cart/post")]
        public async Task<int> Post(int styleId, int quantity)
        {
            return await _cartService.Post(_sessionService.GetId(), styleId, quantity);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _cartService.DeleteItem(id);
        }
    }
}