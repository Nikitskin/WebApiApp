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

        public OrdersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrder(OrderControllerModel order)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<OrderControllerModel, Order>());
            var dbOrder = Mapper.Map<OrderControllerModel, Order>(order);
            _unitOfWork.OrdersRepository.Create(dbOrder);
            Save();
        }

        public async Task<OrderControllerModel> GetOrder(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Task<OrderControllerModel>, Task<Order>>());
            var orderItem = _unitOfWork.OrdersRepository.GetItem(id);
            var order = Mapper.Map<Task<Order>, Task<OrderControllerModel>>(orderItem);
            return await order;
        }

        public void Remove(int id)
        {
            var order = _unitOfWork.OrdersRepository.GetItem(id);
            _unitOfWork.OrdersRepository.Delete(order.Result);
            Save();
        }

        public async Task<List<OrderControllerModel>> GetAllOrders()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Task<List<OrderControllerModel>>, Task<List<Order>>>());
            var list = _unitOfWork.OrdersRepository.GetAll(); 
            return await Mapper.Map<Task<List<Order>>, Task<List<OrderControllerModel>>>(list);
        }

        public void Update(OrderControllerModel order)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<OrderControllerModel, Order>());
            var dbOrder = Mapper.Map<OrderControllerModel, Order>(order);
            _unitOfWork.OrdersRepository.Update(dbOrder);
            Save();
        }

        private void Save()
        {
            _unitOfWork.Save();
        }
    }
}
