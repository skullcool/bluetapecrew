using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Services.Interfaces;
using BlueTapeCrew.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Repositories.Interfaces;

namespace BlueTapeCrew.Web.Services
{
    public class CartService : ICartService, IDisposable
    {
        private readonly ApplicationDbContext _db;
        private readonly ISiteSettingsService _siteSettingsService;
        private readonly ICartRepository _cartRepository;

        public CartService(ISiteSettingsService siteSettingsService, ApplicationDbContext db, ICartRepository cartRepository)
        {
            _db = db;
            _cartRepository = cartRepository;
            _siteSettingsService = siteSettingsService;
        }

        public string GetCartId(HttpContext context)
        {
            var cartId = context.Session.GetString("cartId");
            if (!string.IsNullOrEmpty(cartId)) return cartId;

            cartId = Guid.NewGuid().ToString();
            context.Session.SetString("cartId", cartId);
            return cartId;
        }

        public async Task<IEnumerable<CartItemViewModel>> Get(string sessionId)
        {
            var cartItems = await _cartRepository.GetBy(sessionId);
            return cartItems.Select(x => new CartItemViewModel(x));
        }

        public async Task<CartViewModel> GetCartViewModel(string sessionId)
        {
            var settings = await _siteSettingsService.Get();
            var cartEntities = await _cartRepository.GetBy(sessionId);
            var cart = cartEntities.Select(x => new CartItemViewModel(x));
            if (!cart.Any()) return new CartViewModel();
            
            var subtotal = cart.Sum(x => x.SubTotal);
            decimal shipping = 0;
            if (subtotal < settings.FreeShippingThreshold) shipping = settings.FlatShippingRate;
            var total = subtotal + shipping;

            var model = new CartViewModel
            {
                Count = cart.Sum(x => x.Quantity),
                Items = cart,
                SubTotal = $"{subtotal:n2}",
                Shipping = $"{shipping:n2}",
                Total = $"{total:n2}"
            };
            return model;
        }

        public async Task<int> Post(string sessionId, int styleId, int quantity)
        {
            var temp = _db.Carts.Where(x => x.CartId.Equals(sessionId)).ToList();
            var style = temp.FirstOrDefault(x => x.StyleId == styleId);

            if (style == null)
            {
                _db.Carts.Add(new Cart
                {
                    CartId = sessionId,
                    StyleId = styleId,
                    Count = quantity,
                    DateCreated = DateTime.UtcNow
                });
            }
            else
            {
                style.Count = style.Count + quantity;
                style.DateCreated = DateTime.UtcNow;
            }
            await _db.SaveChangesAsync();
            return 1;
        }

        public async Task DeleteItem(int id)
        {
            var temp = await _db.Carts.FindAsync(id);
            if (temp == null) return;
            if (temp.Count < 2) _db.Carts.Remove(temp);
            else if (temp.Count > 1) temp.Count--;
            _db.SaveChanges();
        }

        public async Task EmptyCart(string sessionId)
        {
            foreach (var item in await _db.Carts.Where(x => x.CartId.Equals(sessionId)).ToListAsync())
            {
                _db.Carts.Remove(item);
            }
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}