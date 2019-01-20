using System.Threading.Tasks;
using BlueTapeCrew.Web.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BlueTapeCrew.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public void Update(AccountUpdateViewModel model)
        {
            Email = model.Email;
            FirstName = model.FirstName;
            LastName = model.LastName;
            Address = model.Address;
            State = model.State;
            PostalCode = model.PostalCode;
            City = model.City;
            PhoneNumber = model.PhoneNumber;
        }

        public void Update(CheckoutViewModel model)
        {
            Email = model.Email;
            FirstName = model.FirstName;
            LastName = model.LastName;
            Address = model.Address;
            State = model.State;
            PostalCode = model.Zip;
            City = model.City;
            PhoneNumber = model.Phone;
        }

        public string User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }


        public async Task<IdentityResult> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateAsync(this);
            return userIdentity;
        }
    }

}