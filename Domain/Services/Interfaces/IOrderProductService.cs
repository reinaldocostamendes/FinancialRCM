using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IOrderProductService : IGeneric<OrderProducts>
    {
        Task AddOrderProduct(OrderProducts orderProducts);

        Task<List<OrderProducts>> GetAllOrderProductsByOrderId(Guid Id);

        Task UpdateOrderProduct(OrderProducts orderProducts);

        Task DeleteOrderProduct(Guid Id);
    }
}