﻿using System.Collections.Generic;

namespace BlueTapeCrew.Web.Models
{
    public class MenuCategory
    {
        public string Name { get; set; }
        public Dictionary<string, string> Products { get; set; }
    }
}
