﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class MenuViewModel
    {
        [Key]        
        public int Id { get; set; }
        public string MenuName { get; set; }
        public IEnumerable<MenuItemViewModel> Items { get; set; }
    }
}
