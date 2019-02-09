using System.Collections.Generic;

namespace BlueTapeCrew.Web.ViewModels
{
    public class CartViewModel
    {
        public string SubTotal { get; set; }
        public string Shipping { get; set; }
        public string Total { get; set; }
        public int Count { get; set; }
        public IEnumerable<CartItemViewModel> Items { get; set; }
    }
}