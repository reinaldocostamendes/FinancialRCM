using Entities.Entities;
using Entities.Validadors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Helper
{
    public static class OrderHelper
    {
        public  static bool InvalidOrder(Order order)
        {
            var validator = new OrderValidator();
            var result = validator.Validate(order);
            return (!result.IsValid);
        }
        public static bool ValidOrder(Order order)
        {
            var validator = new OrderValidator();
            var result = validator.Validate(order);
            return (result.IsValid);
        }
    }
}
