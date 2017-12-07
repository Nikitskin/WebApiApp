using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPITestApp.DTOLib;

namespace WebAPITestApp.ServiceLayer.DatabaseServices.Orders
{
    public interface IOrdersService
    {
        Task AddOrder(OrderDto order);
        Task<OrderDto> GetOrder(int id);
        Task Remove(int id);
        Task<List<OrderDto>> GetAllOrders();
        Task Update(OrderDto order);
    }
}
