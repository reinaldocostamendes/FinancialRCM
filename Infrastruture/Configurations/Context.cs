using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastruture.Configurations
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) :base(options)
        {
        }

        public DbSet<CashBook> CashBook { get; set; }
        public DbSet<Order> Order { get; set; } 
        public DbSet<Document> Document { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
    }
}
