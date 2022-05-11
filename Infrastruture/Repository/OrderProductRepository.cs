using Domain.Interfaces;
using Entities.Entities;
using Infrastruture.Configurations;
using Infrastruture.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Repository
{
    public class OrderProductRepository : GenericRepository<OrderProducts>, IOrderProductRepository
    {
        private readonly DbContextOptions<FinancialContext> dbContextOptions;

        public OrderProductRepository(DbContextOptions<FinancialContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public async Task AddOrderProduct(OrderProducts orderProducts)
        {
            await base.Post(orderProducts);
        }

        public async Task<List<OrderProducts>> GetAllOrderProductsByOrderId(Guid orderId)
        {
            using (var db = new FinancialContext(dbContextOptions))
            {
                return await db.OrderProducts.Where(o => o.OrderId == orderId).AsNoTracking().ToListAsync();
            }
        }

        public async Task DeleteOrderProduct(Guid id)
        {
            var orderProduct = await base.GetById(id);
            await base.Delete(orderProduct);
        }

        public async Task UpdateOrder(OrderProducts orderProduct)
        {
            await base.Put(orderProduct);
        }

        public async Task UpdateOrderProduct(OrderProducts orderProduct)
        {
            await base.Put(orderProduct);
        }
    }
}