using DatabaseLayer.DbData;
using System.Data.Entity;

namespace DatabaseLayer.Contexts
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("DBConnection")
        {

        }

        public DbSet<Order> Orders { get; set; }

    }
}
