using System.Collections.Generic;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetBy(string sessionId);
    }
}