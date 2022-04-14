using Application.Interfaces;
using Domain.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applications
{
    public class OrderProductApplication : IOrderProductApplication
    {
        IOrderProduct _iorderProduct;
        public async Task<bool> AddOrderProduct(OrderProducts orderProducts)
        {
            return await _iorderProduct.AddOrderProduct(orderProducts);   
        }
    }
}
