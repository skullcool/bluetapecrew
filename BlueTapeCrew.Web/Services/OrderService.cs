using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTapeCrew.Web.Services
{
    public class OrderService : IOrderService, IDisposable
    {
        private readonly ApplicationDbContext _db;

        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddOrder(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _db.Orders.Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersBy(string userName)
        {
            return await _db.Orders.Include(x => x.OrderItems)
                                   .Where(x => x.UserName == userName)
                                   .OrderByDescending(x => x.DateCreated).ToListAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}