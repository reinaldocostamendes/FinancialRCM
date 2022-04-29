using Entities.Entities;
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
            if (product == null) { return true; }
            else
                if (product.Id.Equals("") || product.ProductId.Equals("") || product.ProductDescription.Equals("")
                || product.ProductCategory.Equals("") || product.Quantity.Equals("") || product.Value.Equals("")
                || product.Total.Equals(""))
                return true;
            return false;
        }
    }
}
