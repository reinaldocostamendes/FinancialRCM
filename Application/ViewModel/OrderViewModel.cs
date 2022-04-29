using Application.DTOs;
using Entities.Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public long Code { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        public Guid Client { get; set; }

        public string ClientDescription { get; set; }

        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public OrderStatus Status { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Sector { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal ProductsValues { get; set; }
        public decimal Discount { get; set; }
        public decimal CostValue { get; set; }
        public decimal TotalValue { get; set; }

        public List<OrderProducts> OrderProducts { get; set; }
    }
}
