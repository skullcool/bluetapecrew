﻿using System;

namespace Api.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public int StyleId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }

        public virtual Style Style { get; set; }
    }
}
