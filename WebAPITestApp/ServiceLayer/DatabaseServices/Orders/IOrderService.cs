using System.Threading.Tasks;
using DBLayer.DbData;
using System.Collections.Generic;
using ServiceLayer.Models;

namespace ServiceLayer.DatabaseServices.Orders
{
    public interface IOrdersService
    {
        void AddOrder(OrderControllerModel order);
        Task<OrderControllerModel> GetOrder(int id);
        void Remove(int id);
        Task<List<OrderControllerModel>> GetAllOrders();
        void Update(OrderControllerModel order);
    }
}
