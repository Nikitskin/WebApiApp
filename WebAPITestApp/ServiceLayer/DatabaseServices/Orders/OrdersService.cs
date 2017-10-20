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
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddOrder(OrderDto order)
        {
            var dbOrder = Mapper.Map<OrderDto, Order>(order);
            _unitOfWork.OrdersRepository.Create(dbOrder);
            Save();
        }

        public async Task<OrderDto> GetOrder(int id)
        {
            var orderItem = _unitOfWork.OrdersRepository.GetItem(id);
            var order = Mapper.Map<Task<Order>, Task<OrderDto>>(orderItem);
            return await order;
        }

        public void Remove(int id)
        {
            var order = _unitOfWork.OrdersRepository.GetItem(id);
            _unitOfWork.OrdersRepository.Delete(order.Result);
            Save();
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            var list = _unitOfWork.OrdersRepository.GetAll(); 
            return await Mapper.Map<Task<List<Order>>, Task<List<OrderDto>>>(list);
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
