using System.Threading.Tasks;
using BlueTapeCrew.Web.Models;

namespace BlueTapeCrew.Web.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(SmtpRequest request);
    }
}