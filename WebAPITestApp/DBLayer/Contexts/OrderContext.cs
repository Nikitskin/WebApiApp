using Microsoft.EntityFrameworkCore;
using WebAPITestApp.DBLayer.DbData;

namespace WebAPITestApp.DBLayer.Contexts
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(x => new { x.OrderId, x.ProductId});
            modelBuilder.Entity<OrderProduct>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.OrderProduct)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderProduct>()
                .HasOne(pt => pt.Order)
                .WithMany(t => t.OrderProduct)
                .HasForeignKey(pt => pt.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
