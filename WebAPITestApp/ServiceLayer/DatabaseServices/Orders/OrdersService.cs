using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.UnitOfWork;
using DBLayer.DbData;
using AutoMapper;
using DTOLib;

namespace ServiceLayer.DatabaseServices.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrder(OrderDto order)
        {
            var dbOrder = Mapper.Map<OrderDto, Order>(order);
            var users = await _unitOfWork.UsersRepository.GetAll();
            dbOrder.User = users.FirstOrDefault(name => name.FirstName.Equals(order.UserName));
            _unitOfWork.OrdersRepository.Create(dbOrder);
            await Save();
        }

        public async Task<OrderDto> GetOrder(int id)
        {
            var orderItem = await _unitOfWork.OrdersRepository.GetItem(id);
            var order = Mapper.Map<Order, OrderDto>(orderItem);
            return order;
        }

        public async Task Remove(int id)
        {
            var order = await _unitOfWork.OrdersRepository.GetItem(id);
            _unitOfWork.OrdersRepository.Delete(order);
            await Save();
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            var list = await _unitOfWork.OrdersRepository.GetAll(); 
            return Mapper.Map<List<Order>, List<OrderDto>>(list);
        }

        public async Task Update(OrderDto order)
        {
            var dbOrder = Mapper.Map<OrderDto, Order>(order);
            _unitOfWork.OrdersRepository.Update(dbOrder);
            await Save();
        }

        private async Task Save()
        {
            await _unitOfWork.Save();
        }
    }
}
