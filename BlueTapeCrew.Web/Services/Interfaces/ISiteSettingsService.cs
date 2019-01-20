using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.Services.Interfaces
{
    public interface ISiteSettingsService
    {
        Task<SiteSetting> Get();
        Task<SiteSetting> Set(SiteSetting siteSetting);
    }
}
