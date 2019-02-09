using System;
using System.Collections.Generic;
using System.Linq;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.ViewModels;

namespace BlueTapeCrew.Web.Models.Paypal
{
    public class PaymentRequest
    {
        private const string MoneyFormat = "0.00";
        private const string SandboxMode = "sandbox";
        private const string LiveMode = "live";

        public PaymentRequest(Uri requestUri, SiteSetting settings, IList<CartItemViewModel> cart, int invoiceNumber, string accessToken, bool isSandbox = true)
        {
            InitApiCredentialsForMode(settings, isSandbox);
            Init(settings, cart);
            ItemList = GetItemListFrom(cart);
            InvoiceNumber = invoiceNumber.ToString();
            ReturnUrl = $"{requestUri.Scheme}://{requestUri.Authority}/checkoutreview";
        }

        public string Currency => "USD";
        public string PaymentDescription => "BlueTapeCrew.com Purchase";
        public string PaymentMethod => "paypal";
        public string Intent => "sale";
        public string Mode;

        public string Shipping { get; set; }
        public string Tax => 0.ToString(MoneyFormat);
        public string Subtotal { get; set; }

        public string AccessToken { get; set; }
        public ItemList ItemList { get; set; }
        public string InvoiceNumber { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Total { get; set; }
        public string ReturnUrl { get; set; }

        private void InitApiCredentialsForMode(SiteSetting settings, bool isSandbox)
        {
            if (isSandbox)
            {
                Mode = SandboxMode;
                ClientId = settings.PaypalSandBoxClientId;
                ClientSecret = settings.PaypalSandBoxSecret;

            }
            else
            {
                Mode = LiveMode;
                ClientId = settings.PaypalClientId;
                ClientSecret = settings.PaypalClientSecret;
            }
        }

        private void Init(SiteSetting settings, IEnumerable<CartItemViewModel> cart)
        {
            const decimal tax = 0.00m;
            var subTotal = CalculateSubTotal(cart);
            var shipping = CalculateShipping(settings, subTotal);
            var total = subTotal + tax + shipping;

            Subtotal = subTotal.ToString(MoneyFormat);
            Total = total.ToString(MoneyFormat);
            Shipping = shipping.ToString(MoneyFormat);
        }

        private static decimal CalculateShipping(SiteSetting settings, decimal subtotal)
        {
            return subtotal > settings.FreeShippingThreshold
                        ? 0
                        : settings.FlatShippingRate;
        }

        private static decimal CalculateSubTotal(IEnumerable<CartItemViewModel> cart)
        {
            var subTotal = cart.Where(item => item.SubTotal != null).Aggregate(0.00m, (current, item) => current + (decimal)item.SubTotal);
            return subTotal;
        }

        private static ItemList GetItemListFrom(IEnumerable<CartItemViewModel> cart)
        {
            var itemList = new ItemList
            {
                Items = new List<Item>()
            };

            foreach (var item in cart)
            {
                itemList.Items.Add(new Item
                {
                    Name = item.ProductName,
                    Currency = "USD",
                    Price = item.Price.ToString(MoneyFormat),
                    Quantity = item.Quantity.ToString(),
                    Sku = item.Id.ToString(),
                    Description = item.Description,
                    Url = $"https://bluetapecrew.com/products/{item.LinkName}",
                    Tax = 0.ToString(MoneyFormat)
                });
            }

            return itemList;
        }

    }
}