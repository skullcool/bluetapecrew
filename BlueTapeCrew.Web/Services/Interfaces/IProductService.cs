﻿using BlueTapeCrew.Web.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlueTapeCrew.Web.ViewModels;

namespace BlueTapeCrew.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductViewModel> GetProductViewModel(string name);

        Task<string> AddReview(int productId, string name, string email, string review, decimal rating);
        Task<IEnumerable<Product>> GetBestSellers(int count=3);
        Task<string> GetStylePrice(int id);
    }
}
