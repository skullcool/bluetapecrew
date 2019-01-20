namespace BlueTapeCrew.Web.Models.Entities
{
    public class Invoice
    {
        public Invoice(string sessionId)
        {
            SessionId = sessionId;
        }

        public int Id { get; set; }
        public string SessionId { get; set; }
        public bool Paid { get; set; }
    }
}