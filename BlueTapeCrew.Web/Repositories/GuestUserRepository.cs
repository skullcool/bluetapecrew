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

        public async Task CreateGuestUser(string sessionId, string firstName, string lastName, string address, string city, string state,
            string zip, string phone, string email)
        {
            var dbUser = new GuestUser
            {
                SessionId = sessionId,
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                City = city,
                State = state,
                PostalCode = zip,
                PhoneNumber = phone,
                Email = email,
            };
            _db.GuestUsers.Add(dbUser);
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
