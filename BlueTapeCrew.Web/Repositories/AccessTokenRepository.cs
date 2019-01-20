using System;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Models.Enums;
using BlueTapeCrew.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlueTapeCrew.Web.Repositories
{
    public class AccessTokenRepository : IAccessTokenRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;

        public AccessTokenRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<AccessToken> GetFirst(TokenType tokenType)
        {
            return await _db.AccessTokens.FirstOrDefaultAsync(x => x.TokenType == tokenType);
        }

        public async Task Create(AccessToken token)
        {
            _db.AccessTokens.Add(token);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var accessToken = await _db.AccessTokens.FindAsync(id);
            if (accessToken != null)
            {
                _db.AccessTokens.Remove(accessToken);
                await _db.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}