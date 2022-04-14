using Domain.Interfaces;
using Entities.Entities;
using Infrastruture.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Repository
{
    public class OrderProductRepository 
    {
        private readonly Context _context;

        public OrderProductRepository(Context context)
        {
            _context = context;
        }

        public async Task AddOrderProduct(OrderProducts orderProducts)
        {
            await _context.AddAsync(orderProducts);
            await _context.SaveChangesAsync();
        }
    }
}
