using System.Collections.Generic;
using BlueTapeCrew.Web.Models;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.ViewModels
{
    public class ManageViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<Order> Orders { get; set; } 
    }
}