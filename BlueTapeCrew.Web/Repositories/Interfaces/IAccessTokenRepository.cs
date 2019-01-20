using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Models.Enums;

namespace BlueTapeCrew.Web.Repositories.Interfaces
{
    public interface IAccessTokenRepository
    {
        Task<AccessToken> GetFirst(TokenType tokenType);
        Task Create(AccessToken token);
        Task Delete(int id);
    }
}