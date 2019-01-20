using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.Repositories.Interfaces
{
    public interface IGuestUserRepository
    {
        Task CreateGuestUser(string sessionId, string firstName, string lastName,
            string address, string city, string state, string zip, string phone, string email);

        Task<GuestUser> GetGuestUser(string sessionId);
    }
}
