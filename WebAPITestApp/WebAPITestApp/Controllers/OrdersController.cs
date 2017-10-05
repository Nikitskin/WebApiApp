using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;
using DBLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace WebAPITestApp.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<List<Order>> Get()
        {
            // TODO You should understand that it's not good option to work with data in controllers.
            //You should have separate layer for business logic that works with data.
            // TODO It's better to create separate response models and map db data to this models every time. Automapper nuget will help with it.
            return await _unitOfWork.OrdersRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await _unitOfWork.OrdersRepository.GetItem(id);
        }

        [HttpPost]
        public void Post([FromBody]Order value)
        {
            _unitOfWork.OrdersRepository.Update(value);
            _unitOfWork.Save();
        }

        [HttpPut("{id}")]
        public void Put([FromBody]Order value)
        {
            _unitOfWork.OrdersRepository.Create(value);
            _unitOfWork.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(Order order)
        {
            _unitOfWork.OrdersRepository.Delete(order);
            _unitOfWork.Save();
        }
    }
}
