using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.Repositories.Interfaces
{
    public interface ISiteSettingsRepository
    {
        Task<SiteSetting> Get();
        Task<SiteSetting> Set(SiteSetting siteSetting);
    }
}