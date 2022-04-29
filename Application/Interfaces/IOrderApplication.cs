using Application.DTOs;
using Application.ViewModel;
using Entities.Entities;
using Entities.Enums;
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
        Task<List<Order>> GetAllOrders(int pageIndex, int pageSize);

        Task<Order> GetOrdersByCode(long code);
        Task<Order> GetOrdersByClient(Guid id);
        Task UpdateOrder(OrderViewModel order);
        Task UpdateOrderStatus(Guid id, OrderStatus orderStatus);
        Task DeleteOrder(Guid id);

    }
}
