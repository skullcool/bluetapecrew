using System.Collections.Generic;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.Repositories.Interfaces
{
    public interface ICategoryProductsRepository
    {
        Task<IEnumerable<Category>> Get(bool includeStyles = false);
    }
}