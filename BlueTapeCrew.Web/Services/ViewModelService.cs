using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Repositories.Interfaces;
using BlueTapeCrew.Web.Services.Interfaces;
using BlueTapeCrew.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Exceptions;

namespace BlueTapeCrew.Web.Services
{
    public class ViewModelService : IViewModelService, IDisposable
    {
        private readonly ICategoryProductsRepository _categoryRepository;

        private readonly ApplicationDbContext _db;

        public ViewModelService(ApplicationDbContext db, ICategoryProductsRepository categoryRepository)
        {
            _db = db;
            _categoryRepository = categoryRepository;
        }

        public async Task<HomeViewModel> GetHomeViewModel()
        {
            var settings = await _db.SiteSettings.FirstOrDefaultAsync();
            var catalog = new List<CatalogModel>();

            var categories = await _categoryRepository.Get(includeStyles: true);
            if(categories == null || !categories.Any()) throw new ConfigurationNotFoundException("No site categories found");

            foreach (var category in categories.OrderByDescending(x => x.ProductCategories.Select(p => p.Product).Count()))
            {
                var catalogModel = new CatalogModel
                {
                    CategoryName = category.CategoryName,
                    Products = new List<ProductsAzViewModel>()
                };
                foreach (var item in category.ProductCategories.Select(x => x.Product).OrderBy(x => x.ProductName))
                {
                    catalogModel.Products.Add(new ProductsAzViewModel
                    {
                        Id = item.Id,
                        Name = item.ProductName,
                        LinkName = item.LinkName,
                        Price = $"{item.Styles.FirstOrDefault()?.Price:n2}",
                        ImgSource = "images/" + item.LinkName + ".jpg"
                    });
                }
                catalog.Add(catalogModel);
            }
            return (new HomeViewModel
            {
                Catalog = catalog,
                SiteTitle = settings.SiteTitle,
                Description = settings.Description
            });
        }

        public async Task<IEnumerable<MenuViewModel>> GetSidebarViewModel()
        {
            return await _db.Categories.Where(x => x.Published).OrderBy(x => x.CategoryName).Select(item => new MenuViewModel
            {
                Id = item.Id,
                MenuName = item.CategoryName,
                Items = item.ProductCategories.Select(x => x.Product).OrderBy(x => x.ProductName).Select(product => new MenuItemViewModel
                {
                    LinkName = product.LinkName,
                    ItemName = product.ProductName
                })
            }).ToListAsync();
        }

        public async Task<LayoutViewModel> GetLayoutViewModel()
        {
            var settings = await _db.SiteSettings.FirstOrDefaultAsync();
            if(settings == null) throw  new ConfigurationNotFoundException("No Site Settings Found");
            return new LayoutViewModel
            {
                ContactEmail = settings.ContactEmailAddress,
                ContactPhone = settings.ContactPhoneNumber,
                Description = settings.Description,
                Keywords = settings.Keywords,
                AboutUs = settings.AboutUs,
                TwitterWidgetId = settings.TwitterWidgetId,
                SiteTitle = settings.SiteTitle,
                TwitterUrl = settings.TwitterUrl,
                FaceBookUrl = settings.FaceBookUrl,
                LinkedInUrl = settings.LinkedInUrl,
                CopyrightLinktext = settings.CopyrightLinktext,
                CopyrightText = settings.CopyrightText,
                CopyrightUrl = settings.CopyrightUrl,
                Menu = await _db.Categories.Where(x => x.Published).OrderBy(x => x.CategoryName).Select(item => new MenuViewModel
                {
                    Id = item.Id,
                    MenuName = item.CategoryName,
                    Items = item.ProductCategories.Select(x => x.Product).OrderBy(x => x.ProductName).Select(product => new MenuItemViewModel
                    {
                        LinkName = product.LinkName,
                        ItemName = product.ProductName
                    })
                }).ToListAsync()
            };
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}