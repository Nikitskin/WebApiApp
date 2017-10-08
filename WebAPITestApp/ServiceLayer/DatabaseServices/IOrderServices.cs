
using System.Collections.Generic;
using DBLayer.DbData;

namespace ServiceLayer.DatabaseServices
{
    public interface IOrderServices
    {
        bool AddOrder(Order order);
        Order GetOrder(int id);
        bool Remove(int id);
        bool Remove(Order order);
        ICollection<Order> GetAllOrders();
        bool Update(Order order);
    }
    
}
