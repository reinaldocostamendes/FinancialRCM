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
    public class OrderApplication : IOrderApplication
    {
        IOrder _iorder;

        public OrderApplication(IOrder iorder)
        {
            _iorder = iorder;
        }

        public async Task<bool> AddOrder(Order order)
        {
           return await _iorder.AddOrder(order);  
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

        public async Task<bool> UpdateOrder(Order order)
        {
            return await _iorder.UpdateOrder(order);
        }

        public async Task<bool> UpdateOrderStatus(Order order)
        {
            return await _iorder.UpdateOrderStatus(order);
        }
    }
}
