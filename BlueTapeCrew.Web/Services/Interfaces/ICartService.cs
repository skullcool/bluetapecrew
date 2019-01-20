using System.Collections.Generic;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.ViewModels;
using Microsoft.AspNetCore.Http;

namespace BlueTapeCrew.Web.Services.Interfaces
{
    public interface ICartService
    {
        string GetCartId(HttpContext context);
        Task<IEnumerable<CartView>> Get(string sessionId);
        Task<CartViewModel> GetCartViewModel(string sessionId);
        Task<int> Post(string sessionId, int styleId, int quantity);
        Task DeleteItem(int id);
        Task EmptyCart(string sessionId);
    }
}