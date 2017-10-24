using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.UnitOfWork;
using ServiceLayer.Models;
using DBLayer.DbData;
using AutoMapper;

namespace ServiceLayer.DatabaseServices.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrder(OrderDto order)
        {
            var dbOrder = Mapper.Map<OrderDto, Order>(order);
            _unitOfWork.OrdersRepository.Create(dbOrder);
            Save();
        }

        public async Task<OrderDto> GetOrder(int id)
        {
            var orderItem = await _unitOfWork.OrdersRepository.GetItem(id);
            var order = Mapper.Map<Order, OrderDto>(orderItem);
            return order;
        }

        public void Remove(int id)
        {
            var order = _unitOfWork.OrdersRepository.GetItem(id);
            _unitOfWork.OrdersRepository.Delete(order.Result);
            Save();
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            var list = await _unitOfWork.OrdersRepository.GetAll(); 
            return Mapper.Map<List<Order>, List<OrderDto>>(list);
        }

        public void Update(OrderDto order)
        {
            var dbOrder = Mapper.Map<OrderDto, Order>(order);
            _unitOfWork.OrdersRepository.Update(dbOrder);
            Save();
        }

        private void Save()
        {
            _unitOfWork.Save();
        }
    }
}
