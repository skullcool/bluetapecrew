using System;
using BlueTapeCrew.Web.Extensions;
using BlueTapeCrew.Web.Models;
using BlueTapeCrew.Web.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BlueTapeCrew.Web.Services
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string SessionKey = "btcSession";

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetId()
        {
            var session = GetSession();
            if (session != null) return session.SessionId;
            var sessionId = Guid.NewGuid().ToString();
            SetSession(new SessionContext(sessionId));
            return sessionId;
        }

        public void SetCategory(string name)
        {
            var session = GetSession();
            session.CurrentCategory = name;
            SetSession(session);
        }

        public void SetProduct(int productId)
        {
            var session = GetSession();
            session.CurentProductId = productId;
            SetSession(session);
        }

        private SessionContext GetSession()
        {
            return _httpContextAccessor.HttpContext.Session.Get<SessionContext>(SessionKey);
        }

        private void SetSession(SessionContext session)
        {
            _httpContextAccessor.HttpContext.Session.Set(SessionKey, session);
        }
    }
}
