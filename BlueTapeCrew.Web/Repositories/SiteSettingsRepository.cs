using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlueTapeCrew.Web.Repositories
{
    public class SiteSettingsRepository : ISiteSettingsRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;

        public SiteSettingsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<SiteSetting> Get()
        {
            var settings = await _db.SiteSettings.FirstOrDefaultAsync();
            return settings;
        }

        public async Task<SiteSetting> Set(SiteSetting siteSetting)
        {
            var entity = await _db.SiteSettings.FindAsync(siteSetting.Id);
            _db.Entry(entity).CurrentValues.SetValues(siteSetting);
            await _db.SaveChangesAsync();
            return entity;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}