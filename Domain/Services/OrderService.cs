using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Entities;
using Entities.PageParam;
using Entities.Validadors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task AddOrder(Order order)
        {
            var validator = new OrderValidator();
            var result = validator.Validate(order);
            if (!result.IsValid) { throw new Exception(); }
            await _orderRepository.AddOrder(order);
        }

        public async Task DeleteOrder(Guid id)
        {
            await _orderRepository.DeleteOrder(id);
        }

        public async Task<List<Order>> GetAllOrders([FromBody] PageParameters pageParameters)
        {
            return await _orderRepository.GetAllOrders(pageParameters);
        }

        public async Task<Order> GetOrdersByClientId(Guid id)
        {
            return await _orderRepository.GetOrdersByClientId(id);
        }

        public async Task<Order> GetByIdOrder(Guid id)
        {
            return await _orderRepository.GetByIdOrder(id);
        }

        public async Task<Order> GetOrdersByCode(long code)
        {
            return await _orderRepository.GetOrdersByCode(code);
        }

        public async Task UpdateOrder(Order order)
        {
            var validator = new OrderValidator();
            var result = validator.Validate(order);
            if (!result.IsValid) { throw new Exception(); }
            await _orderRepository.UpdateOrder(order);
        }

        public async Task UpdateOrderStatus(Order order)
        {
            var validator = new OrderValidator();
            var result = validator.Validate(order);
            if (!result.IsValid) { throw new Exception(); }
            await _orderRepository.UpdateOrder(order);
        }
    }
}