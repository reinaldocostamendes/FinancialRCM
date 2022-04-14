using Entities.Enums;
using System;
using System.Collections.Generic;

namespace FIinancial_API.DTOs
{
    public class OrderDTO
    {
        public long Code { get; set; }  
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<OrderProductDTO> Produts { get; set; }
        public Guid Client { get; set; }
        public string ClientDescription { get; set; }
        public string ClientEmail{ get; set; }
        public string ClientPhone { get; set; }
        public OrderStatus Status { get; set; }
        public string Street { get; set; }

        public string Number { get; set; }
        public string Sector { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Discount { get; set; }
        public decimal Cost { get; set; }
    }
}
