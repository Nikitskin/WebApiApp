using System.Threading.Tasks;
using DBLayer.DbData;
using System.Collections.Generic;

namespace ServiceLayer.DatabaseServices.Orders
{
    public interface IOrdersService
    {
        void AddOrder(Order order);
        Task<Order> GetOrder(int id);
        void Remove(int id);
        void Remove(Order order);
        Task<List<Order>> GetAllOrders();
        void Update(Order order);
    }
}
