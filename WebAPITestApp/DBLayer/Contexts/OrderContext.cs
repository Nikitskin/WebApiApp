using DBLayer.DbData;
using System.Data.Entity;

namespace DBLayer.Contexts
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("DBConnection")
        {
        }

        public DbSet<Order> Orders { get; set; }

    }
}
