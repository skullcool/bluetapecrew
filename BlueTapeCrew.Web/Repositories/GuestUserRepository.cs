using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlueTapeCrew.Web.Repositories
{
    public class GuestUserRepository : IGuestUserRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;

        public GuestUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateGuestUser(GuestUser user)
        {
            _db.GuestUsers.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task<GuestUser> GetGuestUser(string sessionId)
        {
            return await _db.GuestUsers.FirstOrDefaultAsync(x => x.SessionId.Equals(sessionId));
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
