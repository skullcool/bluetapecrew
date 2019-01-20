using System.Collections.Generic;

namespace BlueTapeCrew.Web.ViewModels
{
    public class CatalogModel
    {
        public string CategoryName { get; set; }
        public IList<ProductsAzViewModel> Products { get; set; }
    }
}