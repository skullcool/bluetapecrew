using Newtonsoft.Json;

namespace BlueTapeCrew.Web.Models.Paypal
{
    public class PaypalTokenResult
    {
        public string Scope { get; set; }
        public string Nonce { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }
    }
}