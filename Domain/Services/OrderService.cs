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
    public class OrderService : IOrder
    {
        public async Task AddOrder(Order order)
        {
            var validator =new OrderValidator();
            var result = validator.Validate(order);
            if (!result.IsValid) { throw new Exception(); }
           await  AddOrder(order);
            
        }

        public async Task DeleteOrder(Guid id)
        {
            await DeleteOrder(id);
        }

        public async Task<List<Order>> GetAllOrders(int pageIndex, int pageSize)
        {
            return await GetAllOrders(pageIndex, pageSize);
        }

        public async Task<Order> GetOrdersByClientId(Guid id)
        {
           return await GetOrdersByClientId(id);
        }

       

        public async Task<Order> GetOrdersByCode(long code)
        {
            return await GetOrdersByCode(code);
        }

        public async Task UpdateOrder(Order order)
        {
            var validator = new OrderValidator();
            var result = validator.Validate(order);
            if (!result.IsValid) { throw new Exception(); }
            await UpdateOrder(order);
           
        }

        public async Task UpdateOrderStatus(Order order)
        {
            var validator = new OrderValidator();
            var result = validator.Validate(order);
            if (!result.IsValid) { throw new Exception(); }
            await UpdateOrder(order);
           
        }

     
    }
}
