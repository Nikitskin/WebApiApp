using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;
using DBLayer.UnitOfWork;

namespace ServiceLayer.DatabaseServices.Orders
{
    public class OrdersService : IOrdersService
    {
        private IUnitOfWork _unitOfWork;

        public OrdersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrder(Order order)
        {
            _unitOfWork.OrdersRepository.Create(order);
            Save();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _unitOfWork.OrdersRepository.GetItem(id);
        }

        public void Remove(int id)
        {
            var order = _unitOfWork.OrdersRepository.GetItem(id);
            _unitOfWork.OrdersRepository.Delete(order.Result);
            Save();
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
            _unitOfWork.OrdersRepository.Update(order);
            Save();
        }

        private void Save()
        {
            _unitOfWork.Save();
        }
    }
}
