using System.Threading.Tasks;
using System.Collections.Generic;
using DTOLib.DatabaseModels;

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
