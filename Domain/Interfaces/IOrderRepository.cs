using Domain.Interfaces.Generics;
using Entities.Entities;
using Entities.PageParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderRepository : IGeneric<Order>
    {
        Task AddOrder(Order order);

        Task<List<Order>> GetAllOrders(PageParameters pageParameters);

        Task<Order> GetOrdersByCode(long code);

        Task<Order> GetOrdersByClientId(Guid id);

        Task UpdateOrder(Order order);

        Task<Order> GetByIdOrder(Guid id);

        Task UpdateOrderStatus(Order order);

        Task DeleteOrder(Guid id);
    }
}