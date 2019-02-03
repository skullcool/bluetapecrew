using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetBy(string slug);
    }
}
