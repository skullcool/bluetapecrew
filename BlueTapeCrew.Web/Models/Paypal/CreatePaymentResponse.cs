using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlueTapeCrew.Web.Models.Paypal
{
    public class CreatePaymentResponse : PaypalPayment
    {
        public string Id { get; set; }
        public string State { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }

        public List<Link> Links { get; set; }
    }

    public class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
}