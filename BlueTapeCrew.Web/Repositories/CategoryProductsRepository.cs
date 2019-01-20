using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueTapeCrew.Web.Repositories
{
    public class CategoryProductsRepository : ICategoryProductsRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;

        public CategoryProductsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> Get(bool includeStyles = false)
        {
            if (includeStyles)
            {
                return await _db.Categories
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Product)
                    .ThenInclude(x => x.Styles)
                    .ToListAsync();
            }

            return await _db.Categories
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Product)
                .ToListAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}