using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public  interface IOrder
    {
        Task AddOrder(Order order);
        Task<List<Order>> GetAllOrders();

        Task<Order> GetOrdersByCode(long code);
        Task<Order> GetOrdersByClientId(Guid id);
        Task UpdateOrder(Order order);
        Task UpdateOrderStatus(Order order);
        Task DeleteOrder(Guid id);

    }
}
