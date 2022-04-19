using Domain.Interfaces;
using Entities.Entities;
using Entities.Validadors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrderProductService : IOrderProduct
    {
        public async Task AddOrderProduct(OrderProducts orderProducts)
        {
            var validator = new OrderProductValidator();
            var result = validator.Validate(orderProducts);
            if (!result.IsValid) { throw new Exception(); }
            await AddOrderProduct(orderProducts);
            
        }
    }
}
