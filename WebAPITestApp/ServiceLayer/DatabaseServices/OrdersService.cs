using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;
using DBLayer.UnitOfWork;

namespace ServiceLayer.DatabaseServices
{
    public class OrdersService : IOrderServices
    {
        private IUnitOfWork _unitOfWork;

        public OrdersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // TODO Every property, method and constructor should be followed and preceded by empty line.
        public void AddOrder(Order order)
        {
            _unitOfWork.OrdersRepository.Create(order);
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _unitOfWork.OrdersRepository.GetItem(id);
        }

        public void Remove(int id)
        {
            var order = _unitOfWork.OrdersRepository.GetItem(id);
            _unitOfWork.OrdersRepository.Delete(order.Result);
        }

        public void Remove(Order order)
        {
            _unitOfWork.OrdersRepository.Delete(order);
        }

        public Task<List<Order>> GetAllOrders()
        {
            return _unitOfWork.OrdersRepository.GetAll();
        }

        public void Update(Order order)
        {
            // TODO You still don't save changes into DB. Call dbContext.SaveChanges() after update.
            _unitOfWork.OrdersRepository.Update(order);
        }

        private void Save()
        {
            _unitOfWork.Save();
        }
    }
}
