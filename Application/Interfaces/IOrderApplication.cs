using Application.DTOs;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public  interface IOrderApplication
    {
        Task AddOrder(OrderDTO order);
        Task<List<Order>> GetAllOrders();

        Task<Order> GetOrdersByCode(long code);
        Task<Order> GetOrdersByCustumer(Guid id);
        Task UpdateOrder(OrderDTO order);
        Task UpdateOrderStatus(OrderDTO order);
        Task DeleteOrder(Guid id);

    }
}
