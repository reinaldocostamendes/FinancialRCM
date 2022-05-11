using Entities.Entities;
using Entities.Validadors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Helper
{
    public static class ProductHelper
    {
        public static bool InvalidProduct(OrderProducts product)
        {
            var validator = new OrderProductValidator();
           var result =  validator.Validate(product);
            return !result.IsValid;
        }
        public static bool ValidProduct(OrderProducts product)
        {
            var validator = new OrderProductValidator();
            var result = validator.Validate(product);
            return result.IsValid;
        }
    }
}
