using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Repositories.Interfaces;
using BlueTapeCrew.Web.Services.Interfaces;

namespace BlueTapeCrew.Web.Services
{
    public class SiteSettingsService : ISiteSettingsService
    {
        private readonly ISiteSettingsRepository _settingsRepository;

        public SiteSettingsService(ISiteSettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public async Task<SiteSetting> Get()
        {
            return await _settingsRepository.Get();
        }

        public async Task<SiteSetting> Set(SiteSetting siteSetting)
        {
            return await _settingsRepository.Set(siteSetting);
        }
    }
}