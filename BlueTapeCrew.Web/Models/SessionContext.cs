namespace BlueTapeCrew.Web.Models
{
    public class SessionContext
    {
        public SessionContext(string sessionId)
        {
            SessionId = sessionId;
        }

        public string SessionId { get; }
        public string CurrentCategory { get; set; }
        public int CurentProductId { get; set; }
    }
}