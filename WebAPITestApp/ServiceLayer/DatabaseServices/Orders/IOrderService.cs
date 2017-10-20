using System.Threading.Tasks;
using DBLayer.DbData;
using System.Collections.Generic;
using ServiceLayer.Models;

namespace ServiceLayer.DatabaseServices.Orders
{
    public interface IOrdersService
    {
        void AddOrder(OrderDto order);
        Task<OrderDto> GetOrder(int id);
        void Remove(int id);
        Task<List<OrderDto>> GetAllOrders();
        void Update(OrderDto order);
    }
}
