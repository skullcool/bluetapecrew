﻿using BlueTapeCrew.Models;
using BlueTapeCrew.Models.Entities;
using BlueTapeCrew.Repositories.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTapeCrew.Repositories
{
    public class SiteSettingsRepository : ISiteSettingsRepository, IDisposable
    {
        private readonly BtcEntities _db;

        public SiteSettingsRepository()
        {
            _db = new BtcEntities();
        }

        public async Task<SiteSetting> Get()
        {
//            return await _db.SiteSettings.FirstOrDefaultAsync();
            var settings = await _db.SiteSettings.ToListAsync();
            return settings.Last();
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