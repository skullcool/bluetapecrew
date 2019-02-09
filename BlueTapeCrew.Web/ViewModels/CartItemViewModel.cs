using System.Linq;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.ViewModels
{
    public class CartItemViewModel
    {
        private readonly Cart _cartItem;

        public CartItemViewModel(Cart cartItem)
        {
            _cartItem = cartItem;
        }

        public int Id => _cartItem.Id;
        public string CartId => _cartItem.CartId;
        public int Quantity => _cartItem.Count;
        public int ProductId => _cartItem.ProductId;
        public string ProductName => _cartItem.Style.Product.ProductName;
        public string LinkName => _cartItem.Style.Product.LinkName;
        public decimal Price => _cartItem.Style.Price;
        public int StyleId => _cartItem.Style.Id;
        public string ColorText => _cartItem.Style.Color.ColorText;
        public string Description => _cartItem.Style.Product.Description;
        public string StyleText => _cartItem.Style.Product.Description;
        public decimal? SubTotal => _cartItem.Style.Price * _cartItem.Count;
        public byte[] ImageData => _cartItem.Style.Product.CartImages.FirstOrDefault()?.ImageData;
    }
}