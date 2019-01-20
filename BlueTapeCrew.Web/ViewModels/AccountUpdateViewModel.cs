using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlueTapeCrew.Web.Models;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.ViewModels
{
    public class AccountUpdateViewModel
    {
        public AccountUpdateViewModel() { }

        public AccountUpdateViewModel(ApplicationUser user, IEnumerable<Order> orders)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            Address = user.Address;
            City = user.City;
            State = user.State;
            PostalCode = user.PostalCode;
            Orders = orders;
        }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(75)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(20)]
        public string PostalCode { get; set; }

        [StringLength(60)]
        public string FirstName { get; set; }

        [StringLength(60)]
        public string LastName { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
