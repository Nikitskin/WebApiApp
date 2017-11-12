
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;
using Microsoft.EntityFrameworkCore;
using NLogger;

namespace DBLayer.DBRepository
{
    public class OrderRepository : DbRepository<Order>
    {
        public OrderRepository(DbContext context, ILoggerService logger) : base(context, logger)
        {

        }
        public override async Task<Order> GetItem(int id)
        {
            return await DbSet.Include(order => order.OrderProduct).
                ThenInclude(product => product.Product).
                Include(order => order.User).
                FirstAsync(p => p.Id == id);
        }

        public override async Task<List<Order>> GetAll()
        {
            return await DbSet.Include(order => order.OrderProduct).
                ThenInclude(product => product.Product)
                .ToListAsync();
        }

        //public override async void Update(Order item)
        //{
        //    var z = await DbSet.Include(order => order.OrderProduct).FirstAsync(i => i.Id == item.Id);
        //    z.OrderProduct = item.OrderProduct;
        //    DbSet.Update(z);

        //}
    }
}