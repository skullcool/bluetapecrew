using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Services.Interfaces;
using BlueTapeCrew.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTapeCrew.Web.Services
{
    public class ProductService : IProductService, IDisposable
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        private static string GetImgSrc(byte[] imageData, string mimeType)
        {
            return "data:" + mimeType + ";base64," + Convert.ToBase64String(imageData);
        }

        private static string GetMoney(decimal m)
        {
            return m == null ? "0.00" : $"{m:n2}";
        }

        public async Task<ProductViewModel> GetProductViewModel(string name)
        {
            var product = await _db.Products
                .Include(x => x.Styles)
                    .ThenInclude(x => x.Size)
                .Include(x => x.Styles)
                    .ThenInclude(x => x.Color)
                .Include(x => x.Image)
                .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Category)
                .Include(x => x.ProductImages)
                    .ThenInclude(x => x.Image)
                .FirstOrDefaultAsync(x => x.LinkName.Equals(name));

            if (product == null) return null;

            var category = product.ProductCategories.FirstOrDefault()?.Category;
            var styles = product.Styles.OrderBy(x => x.Size.SizeOrder).ThenBy(x => x.Color.ColorText).ToList();
            var styleViews = await _db.StyleViews.Where(x => x.ProductId == product.Id).ToListAsync();
            styleViews = styleViews.OrderBy(x => x.SizeOrder).ThenBy(x => x.ColorText).ToList();

            var additionalImages = product.ProductImages.Select(x => x.Image).ToList().Select(
                    image => GetImgSrc(image.ImageData, image.MimeType))
                .ToList();

            var averageReview = product.Reviews.Any() ? product.Reviews.Average(x => x.Rating) : 0;
            var bestSellers = await _db.Products.Take(3).Select(prod => new BestSellerViewModel
            {
                Id = prod.Id,
                ImgSource = GetImgSrc(prod.Image.ImageData, prod.Image.MimeType),
                LinkName = prod.LinkName,
                Name = prod.LinkName,
                Price = GetMoney(prod.Styles.FirstOrDefault().Price)
            }).ToListAsync();
            var imgSource = GetImgSrc(product.Image.ImageData, product.Image.MimeType) ?? string.Empty;
            var menu = _db.Categories.Where(x => x.Published).OrderBy(x => x.CategoryName).Select(cat =>
                new MenuViewModel
                {
                    Id = cat.Id,
                    MenuName = cat.CategoryName,
                    Items = cat.ProductCategories.Select(x => x.Product).OrderBy(x => x.ProductName).Select(menuItem =>
                        new MenuItemViewModel
                        {
                            Id = menuItem.Id,
                            ItemName = menuItem.ProductName,
                            LinkName = menuItem.LinkName,
                        }).ToList()
                }).ToList();

            var reviews = product.Reviews.OrderByDescending(x => x.DateCreated).Select(review => new ReviewViewModel
            {
                Content = review.ReviewText,
                Date = review.DateCreated.ToString(),
                Id = review.Id,
                Name = review.Name,
                Rating = review.Rating
            }).ToList();

            var model = new ProductViewModel
            {
                Id = product.Id,
                AdditionalImages = additionalImages,
                AverageReview = averageReview,
                BestSellers = bestSellers,
                Description = product.Description,
                ImgSource = imgSource,
                Menu = menu,
                Name = product.ProductName,
                Price = GetMoney(styles.FirstOrDefault()?.Price ?? 0.0m),
                Reviews = reviews,
                StyleId = new SelectList(styleViews, "Id", "StyleText", styleViews.FirstOrDefault())
            };


            if (category != null)
            {
                model.Category = category.CategoryName;
            }

            return model;
        }

        public async Task<string> AddReview(int productId, string name, string email, string review, decimal rating)
        {
            _db.Reviews.Add(new Review
            {
                DateCreated = DateTime.UtcNow,
                Email = email,
                Name = name,
                ProductId = productId,
                Rating = rating,
                ReviewText = review
            });
            await _db.SaveChangesAsync();
            return _db.Products.Find(productId).LinkName;
        }

        public async Task<IEnumerable<Product>> GetBestSellers(int count = 3)
        {
            var randNum = new Random();
            var products = await _db.Products.Include(x => x.Image).Include(x => x.Styles).ToListAsync();
            var model = new List<Product>();
            for (var i = 0; i < count; i++)
            {
                var product = products[randNum.Next(products.Count)];
                products.Remove(product);
                model.Add(product);
            }
            return model;
        }

        public async Task<string> GetStylePrice(int id)
        {
            var style = await _db.Styles.FindAsync(id);
            return $"{style.Price:n2}";
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}