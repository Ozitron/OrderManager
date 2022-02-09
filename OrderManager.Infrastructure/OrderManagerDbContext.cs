using Microsoft.EntityFrameworkCore;
using OrderManager.Core.Entities;

namespace OrderManager.Infrastructure
{
    public class OrderManagerDbContext : DbContext
    {
        public OrderManagerDbContext(DbContextOptions<OrderManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Product> ProductTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
