using Domain.Interfaces;
using Entities.Entities;
using Infrastruture.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Repository
{
    public class OrderRepository 
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public async Task AddOrder(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(Guid id)
        {
            var OrderToDelete = await _context.Document.FindAsync(id);
            _context.Document.Remove(OrderToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Order.ToListAsync();
        }

        public async Task<Order> GetOrdersByCustumer(Guid id)
        {
            return await _context.Order.FirstOrDefaultAsync(o => o.Client == id);
        }

        public async Task<Order> GetOrdersBycCde(long code)
        {
            return await _context.Order.FirstOrDefaultAsync(o => o.Code == code);
        }

        public async Task  UpdateOrder(Order order)
        {
            _context.Order.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderStatus(Order order)
        {
            _context.Order.Update(order);
            await _context.SaveChangesAsync();
        }
    }
    }

