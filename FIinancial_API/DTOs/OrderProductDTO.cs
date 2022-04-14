﻿using System;

namespace FIinancial_API.DTOs
{
    public class OrderProductDTO
    {
        public string ProductDescription { get; set; } 
        public int ProductCategory { get; set; }
        public decimal Quantity { get; set; }
        public decimal Value { get; set; }
      
    }
}
