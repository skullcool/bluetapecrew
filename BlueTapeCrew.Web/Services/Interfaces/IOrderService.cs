using System.Collections.Generic;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddOrder(Order order);
        Task<Order> GetOrder(int id);
        Task<IEnumerable<Order>> GetOrdersBy(string userName);
    }
}