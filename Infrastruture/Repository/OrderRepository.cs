
using Domain.Interfaces;
using Entities.Entities;
using Entities.PageParam;
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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DbContextOptions<FinancialContext> dbContextOptions;

        public OrderRepository(DbContextOptions<FinancialContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public async Task AddOrder(Order order)
        {
           
            await base.Post(order);    
        }
       public async Task<Order> GetByIdOrder(Guid id)
        {
            return await base.GetById(id);  
        }
        public async Task DeleteOrder(Guid id)
        {
            var order = await base.GetById(id);
           await base.Delete(order);
        }

        public async Task<List<Order>> GetAllOrders(PageParameters pageParameters)
        {
            return await base.GetAll(pageParameters); 
        }

        public async Task<Order> GetOrdersByCode(long code)
        {
            using(var db = new FinancialContext(dbContextOptions))
            {
                return await db.Order.Where(o => o.Code == code).AsNoTracking().FirstOrDefaultAsync();
            }
        }

        public async Task<Order> GetOrdersByClientId(Guid id)
        {
            using (var db = new FinancialContext(dbContextOptions))
            {
                return await db.Order.Where(o => o.Client == id).AsNoTracking().FirstOrDefaultAsync();
            }
        }

        public async Task UpdateOrder(Order order)
        {
            await base.Put(order);
        }

        public async Task UpdateOrderStatus(Order order)
        {
            await base.Put(order);
        }
    }
}

