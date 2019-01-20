using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<Invoice> Create(Invoice invoice);
        Task Delete(int id);
    }
}