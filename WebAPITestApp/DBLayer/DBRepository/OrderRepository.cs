using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPITestApp.DBLayer.Contexts;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.NLogger;

namespace WebAPITestApp.DBLayer.DBRepository
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

        public override void Update(Order item)
        {
            var order = Context.Orders.Include(ord => ord.OrderProduct).First(ord => ord.Id == item.Id);
            List<OrderProduct> list = new List<OrderProduct>();
            foreach (var orderProduct in item.OrderProduct)
            {
                OrderProduct temp = order.OrderProduct.FirstOrDefault(a => a.OrderId == orderProduct.OrderId && a.ProductId == orderProduct.ProductId);
                list.Add(temp ?? orderProduct);
            }
            order.OrderProduct = 
                list;
            base.Update(order);
        }
    }
}