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
        Task<bool> AddOrder(Order order);
        Task<List<Order>> GetAllOrders();

        Task<Order> GetOrdersByCode(long code);
        Task<Order> GetOrdersByCustumer(Guid id);
        Task<bool> UpdateOrder(Order order);
        Task<bool> UpdateOrderStatus(Order order);
        Task DeleteOrder(Guid id);

    }
}
