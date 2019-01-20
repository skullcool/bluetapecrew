using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Paypal;
using BlueTapeCrew.Web.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api;

namespace BlueTapeCrew.Web.Services
{

    public class PaypalService : IPaypalService
    {
        private const string PaypalSandboxUrl = "https://api.sandbox.paypal.com/v1/";
        private const string PayPalProductionUrl = "https://api.paypal.com/v1/";

        private const string PaymentsEndpoint = "payments/payment";
        private const string TokenEndpoint = "oauth2/token";

        private static Dictionary<string, string> GetConfig(string mode)
        {
            return new Dictionary<string, string> { { "mode", mode } };
        }

        private readonly ISiteSettingsService _siteSettingsService;

        public PaypalService(ISiteSettingsService siteSettingsService)
        {
            _siteSettingsService = siteSettingsService;
        }

        public async Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest request)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.AccessToken);

            var jsonBody = JsonConvert.SerializeObject(request.PaypalPayment, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{request.Url}{PaymentsEndpoint}", content);
            var json = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CreatePaymentResponse>(json);
            return model;
        }

        public async Task<string> GetAccessToken(bool isSandbox = true)
        {
            var credentials = await GetCredentials(isSandbox);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Language", "en_US");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{credentials.Id}:{credentials.Secret}")));

            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            var repsonse = await client.PostAsync($"{credentials.Url}{TokenEndpoint}", content);
            var result = await repsonse.Content.ReadAsStringAsync();
            var tokenResult = JsonConvert.DeserializeObject<PaypalTokenResult>(result);
            return tokenResult.AccessToken;
        }

        public async Task<APIContext> GetApiContext(PaymentRequest paymentRequest, bool isSandbox = true)
        {
            var apiContext = new APIContext(string.IsNullOrEmpty(paymentRequest.AccessToken)
                                ? await GetAccessToken(isSandbox)
                                : paymentRequest.AccessToken)
            { Config = GetConfig(paymentRequest.Mode) };
            return apiContext;
        }

        public async Task<string> PaywithPaypal(PaymentRequest paymentRequest)
        {
            var apiContext = await GetApiContext(paymentRequest);
            var payment = new PaypalPayment(paymentRequest);
            //var createdPayment = 
            //var createdPayment = payment.Create(apiContext);
            //var redirectUrl = createdPayment.GetApprovalUrl();
            return "";
        }

        public Payment CompletePayment(CompletePaymentRequest paymentRequest)
        {
            var apiContext = new APIContext(paymentRequest.Token);
            var paymentExecution = new PaymentExecution { payer_id = paymentRequest.PayerId };
            var payment = new Payment { id = paymentRequest.PaymentId };
            var executedPayment = payment.Execute(apiContext, paymentExecution);
            return executedPayment;
        }

        public async Task<PaypalCredentials> GetCredentials(bool isSandbox)
        {
            var settings = await _siteSettingsService.Get();
            var credentials = new PaypalCredentials();
            if (isSandbox)
            {
                credentials.Id = settings.PaypalSandBoxClientId;
                credentials.Secret = settings.PaypalSandBoxSecret;
                credentials.Url = PaypalSandboxUrl;
            }
            else
            {
                credentials.Id = settings.PaypalClientId;
                credentials.Secret = settings.PaypalClientSecret;
                credentials.Url = PayPalProductionUrl;
            }
            return credentials;
        }

    }
}