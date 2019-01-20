namespace BlueTapeCrew.Web.Models.Paypal
{
    public class CreatePaymentRequest
    {
        public string AccessToken { get; set; }
        public string Url { get; set; }
        public PaypalPayment PaypalPayment { get; set; }
    }
}