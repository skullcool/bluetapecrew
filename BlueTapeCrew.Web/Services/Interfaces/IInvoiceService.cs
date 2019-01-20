using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice> Create(string sessionId);
        Task Delete(int id);
    }
}
