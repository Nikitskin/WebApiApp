using DBLayer.DbData;
using System.Data.Entity;

namespace DBLayer.Contexts
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("ShopConnection")
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
