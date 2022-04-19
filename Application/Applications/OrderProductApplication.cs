using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
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
        private readonly IOrderProduct _iorderProduct;
        private readonly IMapper _imapper;

        public OrderProductApplication(IOrderProduct iorderProduct, IMapper imapper)
        {
            _iorderProduct = iorderProduct;
            _imapper = imapper;
        }

        public async Task AddOrderProduct(OrderProductDTO orderProducts)
        {
            var op = new OrderProducts();
            var opm =  _imapper.Map(orderProducts,op);    
            await _iorderProduct.AddOrderProduct(opm);   
        }
    }
}
