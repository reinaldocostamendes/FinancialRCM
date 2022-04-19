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
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrder _iorder;
        private readonly IMapper _imapper;

        public OrderApplication(IOrder iorder, IMapper imapper)
        {
            _iorder = iorder;
            _imapper = imapper; 
        }

        public async Task AddOrder(OrderDTO order)
        {
            Order o = new Order();
            var om = _imapper.Map(order, o);
            await _iorder.AddOrder(om);  
        }

        public async Task DeleteOrder(Guid id)
        {
            await _iorder.DeleteOrder(id);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _iorder.GetAllOrders();
        }

        public async Task<Order> GetOrdersByCode(long code)
        {
            return await _iorder.GetOrdersByCode(code);   
        }

        public async Task<Order> GetOrdersByCustumer(Guid id)
        {
           return await _iorder.GetOrdersByCustumer(id);  
        }

        public async Task UpdateOrder(OrderDTO order)
        {
            var o = new Order();
           var om= _imapper.Map(order, o);
             await _iorder.UpdateOrder(om);
        }

        public async Task UpdateOrderStatus(OrderDTO order)
        {
            var o = new Order();
            var om = _imapper.Map(order, o);
            await _iorder.UpdateOrder(om);
        }
    }
}
