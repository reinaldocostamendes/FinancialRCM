using System;

namespace Application.DTOs
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
