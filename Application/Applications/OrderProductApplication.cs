using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Entities;
using Entities.Validadors;
using Infrastruture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applications
{
    public class OrderProductApplication : IOrderProductApplication
    {
        private readonly IOrderProductService _iorderProduct;
        private readonly IMapper _imapper;

        public OrderProductApplication(IOrderProductService iorderProduct, IMapper imapper)
        {
            _iorderProduct = iorderProduct;
            _imapper = imapper;
        }

        public async Task AddOrderProduct(OrderProducts orderProducts)
        {
            var validator = new OrderProductValidator();
            var result = validator.Validate(orderProducts);
            if (!result.IsValid)
            {
                var message = "";
                foreach (var item in result.Errors)
                {
                    message += item.ToString() + "\n";
                }
                throw new Exception(message);
            }
            await _iorderProduct.AddOrderProduct(orderProducts);
        }

        public async Task<List<OrderProducts>> GetAllOrderProductsByOrderId(Guid orderId)
        {
            return await _iorderProduct.GetAllOrderProductsByOrderId(orderId);
        }

        public async Task DeleteOrderProduct(Guid id)
        {
            await _iorderProduct.DeleteOrderProduct(id);
        }

        public async Task UpdateOrderProduct(OrderProducts orderProduct)
        {
            await _iorderProduct.UpdateOrderProduct(orderProduct);
        }
    }
}