﻿using System.Collections.Generic;
using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.ViewModels
{
    public class CartViewModel
    {
        public string SubTotal { get; set; }
        public string Shipping { get; set; }
        public string Total { get; set; }
        public int Count { get; set; }
        public List<CartView> Items { get; set; }
    }
}