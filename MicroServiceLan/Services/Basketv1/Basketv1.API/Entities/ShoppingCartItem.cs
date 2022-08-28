﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketv1.API.Entities
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string ProducId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}