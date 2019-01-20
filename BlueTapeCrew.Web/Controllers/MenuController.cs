using System.Collections.Generic;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Models;
using BlueTapeCrew.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlueTapeCrew.Web.Controllers
{
    [Route("api/menu")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IEnumerable<MenuCategory>> Get()
        {
            return await _menuService.Get();
        }
    }
}