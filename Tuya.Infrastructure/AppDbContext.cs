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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithOne()
            .HasForeignKey(d => d.OrderId);
        }
    }
}
