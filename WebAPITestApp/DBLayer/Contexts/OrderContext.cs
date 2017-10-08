using System;
using System.Collections.Generic;
using System.IO;
using DBLayer.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;

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
                var builder = new DbContextOptionsBuilder<OrderContext>();
                //TODO think about this string and how to move it
                builder.UseSqlServer(
                    "data source=EPUAKHAW1166\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True;");
                return new OrderContext(builder.Options);
            }
        }
    }

   
}
