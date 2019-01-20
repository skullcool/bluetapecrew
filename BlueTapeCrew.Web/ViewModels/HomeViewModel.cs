using System.Collections.Generic;

namespace BlueTapeCrew.Web.ViewModels
{
    public class HomeViewModel
    {
        public string SiteTitle { get; set; }
        public string Description { get; set; }
        public IList<CatalogModel> Catalog { get; set; } = new List<CatalogModel>();
    }
}