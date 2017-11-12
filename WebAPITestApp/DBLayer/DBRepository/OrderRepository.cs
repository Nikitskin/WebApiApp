
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Contexts;
using DBLayer.DbData;
using Microsoft.EntityFrameworkCore;
using NLogger;

namespace DBLayer.DBRepository
{
    public class OrderRepository : DbRepository<Order>
    {
        public OrderRepository(OrderContext context, ILoggerService logger) : base(context, logger)
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

        //todo fix if id has duplicates
        public override void Update(Order item)
        {
            var order = DbSet.Include(ord => ord.OrderProduct).FirstOrDefault(ord => ord.Id == item.Id);
            order.OrderProduct.Add(orderProduct);
            DbSet.Update(order);
        }
    }
}