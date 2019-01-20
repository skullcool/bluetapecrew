using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace BlueTapeCrew.Web.Models.Paypal
{
    public class PaypalPayment
    {
        public PaypalPayment()
        {
        }

        public PaypalPayment(PaymentRequest paymentRequest)
        {
            Intent = paymentRequest.Intent;

            Payer = new Payer
            {
                PaymentMethod = paymentRequest.PaymentMethod
            };

            Transactions = new List<Transaction>
            {
                new Transaction
                {
                    Description = paymentRequest.PaymentDescription,
                    InvoiceNumber = paymentRequest.InvoiceNumber,
                    Amount = new Amount
                    {
                        Currency = paymentRequest.Currency,
                        Total = paymentRequest.Total.ToString(CultureInfo.InvariantCulture),
                        Details = new Details
                        {
                            Tax = paymentRequest.Tax,
                            Shipping = paymentRequest.Shipping,
                            Subtotal = paymentRequest.Subtotal
                        }
                    },
                    ItemList = paymentRequest.ItemList
                }
            };

            RedirectUrls = new RedirectUrls
            {
                CancelUrl = paymentRequest.ReturnUrl + "?cancel=true",
                ReturnUrl = paymentRequest.ReturnUrl
            };
        }


        public string Intent { get; set; }

        public Payer Payer { get; set; }

        public List<Transaction> Transactions { get; set; }

        [JsonProperty("redirect_urls")]
        public RedirectUrls RedirectUrls { get; set; }
    }

    public class RedirectUrls
    {
        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }

        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }
    }

    public class Payer
    {
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }
    }

    public class Transaction
    {
        public string Description { get; set; }

        [JsonProperty("invoice_number")]
        public string InvoiceNumber { get; set; }

        public Amount Amount { get; set; }

        [JsonProperty("item_list")]
        public ItemList ItemList { get; set; }
    }

    public class Amount
    {
        public string Currency { get; set; }
        public string Total { get; set; }
        public Details Details { get; set; }
    }

    public class Details
    {
        public string Subtotal { get; set; }
        public string Shipping { get; set; }
        public string Tax { get; set; }

        [JsonProperty("handling_fee")]
        public string HandlingFee { get; set; }

        [JsonProperty("shipping_discount")]
        public string ShippingDiscount { get; set; }

        public string Insurance { get; set; }

        [JsonProperty("gift_wrap")]
        public string GiftWrap { get; set; }

        public string Fee { get; set; }
    }

    public class ItemList
    {
        public List<Item> Items { get; set; }

        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }

        [JsonProperty("shipping_method")]
        public string ShippingMethod { get; set; }

        [JsonProperty("shipping_phone_number")]
        public string ShippingPhoneNumber { get; set; }
    }

    public class Item
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string Tax { get; set; }
        public string Url { get; set; }

        [JsonProperty("supplementary_data")]
        public List<NameValuePair> SupplimentaryData { get; set; }

        [JsonProperty("postback_data")]
        public List<NameValuePair> PostbackData { get; set; }

        public string Category { get; set; }
        public Measurement Weight { get; set; }
        public Measurement Length { get; set; }
        public Measurement Height { get; set; }
        public Measurement Width { get; set; }
    }

    public class Measurement
    {
        public string Value { get; set; }
        public string Unit { get; set; }
    }

    public class NameValuePair
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ShippingAddress
    {
        public string Id { get; set; }

        [JsonProperty("recipient_name")]
        public string RecipientName { get; set; }

        [JsonProperty("default_address")]
        public bool? DefaultAddress { get; set; }

        [JsonProperty("preferred_address")]
        public bool? PreferredAddress { get; set; }
    }
}