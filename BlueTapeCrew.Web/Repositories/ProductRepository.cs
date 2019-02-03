using System;
using System.Linq;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlueTapeCrew.Web.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> GetBy(string slug)
        {
            return await _db.Products
                .Include(x => x.Styles).ThenInclude(x => x.Size)
                .Include(x => x.Styles).ThenInclude(x => x.Color)
                .Include(x => x.Image)
                .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                .Include(x => x.ProductImages).ThenInclude(x => x.Image)
                .FirstOrDefaultAsync(x => x.LinkName == slug);
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
