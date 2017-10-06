using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using DBLayer.DbData;
using DBLayer.UnitOfWork;

namespace WebAPITestApp.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class OrdersController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<List<Order>> Get()
        {
            // TODO You should understand that it's not good option to work with data in controllers.
            //You should have separate layer for business logic that works with data.
            // TODO It's better to create separate response models and map db data to this models every time. Automapper nuget will help with it.
            return await _unitOfWork.OrdersRepository.GetAll();
        }

        [Authorize]
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await _unitOfWork.OrdersRepository.GetItem(id);
        }

        [Authorize]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public void Post([Microsoft.AspNetCore.Mvc.FromBody]Order value)
        {
            _unitOfWork.OrdersRepository.Update(value);
            _unitOfWork.Save();
        }

        [Authorize]
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public void Put([Microsoft.AspNetCore.Mvc.FromBody]Order value)
        {
            _unitOfWork.OrdersRepository.Create(value);
            _unitOfWork.Save();
        }

        [Authorize]
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public void Delete(Order order)
        {
            _unitOfWork.OrdersRepository.Delete(order);
            _unitOfWork.Save();
        }
    }
}
