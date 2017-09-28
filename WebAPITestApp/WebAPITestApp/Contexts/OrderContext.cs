using System.Data.Entity;
using WebAPITestApp.DbData;

namespace WebAPITestApp.Contexts
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("DBConnection")
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
