using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlueTapeCrew.Web.Repositories
{
    public class CartRepository : ICartRepository, IDisposable
    {
        private ApplicationDbContext _db;

        public CartRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Cart>> GetBy(string sessionId)
        {
            return await _db.Carts
                            .Where(x => x.CartId == sessionId)
                            .Include(x => x.Style)
                                .ThenInclude(x => x.Size)
                            .Include(x => x.Style)
                                .ThenInclude(x => x.Color)
                            .Include(x => x.Style)
                                .ThenInclude(x => x.Product)
                                .ThenInclude(x=>x.CartImages)
                            .OrderByDescending(x => x.Id)
                            .ToListAsync();
        }

        public void Dispose()
        {
        }
    }
}