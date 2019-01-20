using System.Threading.Tasks;
using BlueTapeCrew.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlueTapeCrew.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISessionService _sessionService;

        public ProductsController(IImageService imageService,
                                  IProductService productService,
                                  ISessionService sessionService)
        {
            _productService = productService;
            _sessionService = sessionService;
        }


        [Route("products/{id}")]
        [HttpGet]
        public async Task<ActionResult> Index(string id)
        {
            if (id.ToLower().Equals("details")) return RedirectToAction("Index", "Home");
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index", "Home");
            var productViewModel = await _productService.GetProductViewModel(id);
            if (productViewModel == null) return RedirectToAction("Index", "Home");
            //_sessionService.SetProduct(productViewModel.Id);
            //_sessionService.SetCategory(id);
            ViewBag.ReturnUrl = HttpContext.Request.Host.ToString();
            return View(productViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("addreview")]
        public async Task<ActionResult> AddReview(int productId, string name, string email, string review, decimal rating)
        {
            return RedirectToAction("Details", new { name = await _productService.AddReview(productId, name, email, review, rating) });
        }

        public async Task<PartialViewResult> _BestSellers()
        {
            return PartialView(await _productService.GetBestSellers());
        }

        public async Task<string> GetStylePrice(int id)
        {
            return await _productService.GetStylePrice(id);
        }
    }
}