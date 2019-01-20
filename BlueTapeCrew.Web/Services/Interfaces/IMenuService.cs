using System.Collections.Generic;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Models;

namespace BlueTapeCrew.Web.Services.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuCategory>> Get();
    }
}
