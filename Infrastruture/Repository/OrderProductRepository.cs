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
    public class OrderProductRepository : GenericRepository<OrderProducts>, IOrderProduct
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
    }
}
