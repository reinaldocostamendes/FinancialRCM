using System;

namespace FIinancial_API.DTOs
{
    public class CashBookDTO
    {
        public int Origin { get; set; }
        public Guid OriginId { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public decimal Value { get; set; }
    }
}
