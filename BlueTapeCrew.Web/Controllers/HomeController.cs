using System;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Models;
using BlueTapeCrew.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlueTapeCrew.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IViewModelService _viewModelService;

        public HomeController(IViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await _viewModelService.GetHomeViewModel();
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel()
                {
                        RequestId = ex.Message
                });
            }
        }
    }
}