﻿namespace BlueTapeCrew.Web.Models.Paypal
{
    public class CompletePaymentRequest
    {
        public string Token { get; set; }
        public string PayerId { get; set; }
        public string PaymentId { get; set; }
        public string FinalPaymentAmount { get; set; }
    }
}