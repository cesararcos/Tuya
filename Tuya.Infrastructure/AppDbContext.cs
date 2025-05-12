using Microsoft.EntityFrameworkCore;
using Tuya.Domain.Entities;

namespace Tuya.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<Customer> Customers => Set<Customer>();
        //public DbSet<Order> Orders => Set<Order>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
