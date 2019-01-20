using System.Threading.Tasks;

namespace BlueTapeCrew.Web.Services.Interfaces
{
    public interface IEmailSubscriptionService
    {
        Task<string> Subscribe(string email);
    }
}
