using DBLayer.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBLayer.Contexts
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
        }

        public class OrderContextFactory : IDesignTimeDbContextFactory<OrderContext>
        {
            public OrderContext CreateDbContext(string[] args)
            {
                // TODO You can move it to startup class: services.AddDbContext<OrderContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connection string app setting name")) );
                var builder = new DbContextOptionsBuilder<OrderContext>();
                //TODO think about this string and how to move it
                builder.UseSqlServer(
                    "data source=EPUAKHAW1166\\SQLEXPRESS;Initial Catalog=ShopConnection;Integrated Security=True;");
                return new OrderContext(builder.Options);
            }
        }
    }


}
