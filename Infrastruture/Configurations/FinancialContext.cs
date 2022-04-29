using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastruture.Configurations
{
    public class FinancialContext : DbContext
    {
        public FinancialContext(DbContextOptions<FinancialContext> options) : base(options)
        {
        }

        public DbSet<CashBook> CashBook { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProducts>().HasOne<Order>(o => o.Order).WithMany(p=>p.OrderProducts)
                .HasForeignKey(e=>e.OrderId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }
        public string ObterStringConexao()
        {
            string strcon = "Server=Reinaldo\\SQLEXPRESS; Database = FinancialChallengeDb; Integrated Security = True";
            return strcon;
        }
    }
}

