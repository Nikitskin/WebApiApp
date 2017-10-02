using DBLayer.DbData;
using System.Data.Entity;

namespace DBLayer.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("DBConnection")
        {     
        }

        public DbSet<Product> Product { get; set; }

    }
}
