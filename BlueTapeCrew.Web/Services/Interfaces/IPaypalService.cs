using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Paypal;
using PayPal.Api;

namespace BlueTapeCrew.Web.Services.Interfaces
{
    public interface IPaypalService
    {
        Task<PaypalCredentials> GetCredentials(bool isSandbox);
        Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest request);
        Task<APIContext> GetApiContext(PaymentRequest paymentRequest, bool isSandbox = true);
        Task<string> PaywithPaypal(PaymentRequest paymentRequest);
        Payment CompletePayment(CompletePaymentRequest paymentRequest);
        Task<string> GetAccessToken(bool isSandbox = true);
    }
}