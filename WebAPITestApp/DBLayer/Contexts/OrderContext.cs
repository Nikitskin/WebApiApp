using DBLayer.DbData;
using Microsoft.EntityFrameworkCore;

namespace DBLayer.Contexts
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
