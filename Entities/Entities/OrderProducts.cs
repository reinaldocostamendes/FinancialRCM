using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class OrderProducts
    {
        public Guid Id { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductDescription { get; set; }  
        public ProductCategory ProductCategory { get; set; }
        public decimal Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal Total { get; set; }
    }
}
