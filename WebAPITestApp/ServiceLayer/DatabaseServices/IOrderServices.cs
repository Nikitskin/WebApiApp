
using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;

namespace ServiceLayer.DatabaseServices
{
    public interface IOrderServices
    {
        void AddOrder(Order order);
        Task<Order> GetOrder(int id);
        void Remove(int id);
        void Remove(Order order);
        Task<List<Order>> GetAllOrders();
        void Update(Order order);
    }
    
}
