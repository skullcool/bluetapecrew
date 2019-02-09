using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.Repositories.Interfaces
{
    public interface IGuestUserRepository
    {
        Task CreateGuestUser(GuestUser user);

        Task<GuestUser> GetGuestUser(string sessionId);
    }
}
