using System;
using System.Collections.Generic;
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
        public bool AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Order order)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }

        private void Save()
        {
            _unitOfWork.Save();
        }
    }
}
