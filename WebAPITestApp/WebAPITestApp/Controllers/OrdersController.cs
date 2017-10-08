using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;
using DBLayer.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DatabaseServices;

namespace WebAPITestApp.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IOrderServices _service;

        public OrdersController(IOrderServices service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public ICollection<Order> Get()
        {
            // TODO You should understand that it's not good option to work with data in controllers.
            //You should have separate layer for business logic that works with data.
            // TODO It's better to create separate response models and map db data to this models every time. Automapper nuget will help with it.
            return _service.GetAllOrders();
        }

        [Authorize]
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _service.GetOrder(id);
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody]Order value)
        {
            _service.Update(value);
        }

        [Authorize]
        [HttpPut]
        public void Put([FromBody]Order value)
        {
            _service.AddOrder(value);
        }

        [Authorize]
        [HttpDelete]
        public void Delete([FromBody]Order order)
        {
            _service.Remove(order);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int order)
        {
            _service.Remove(order);
        }
    }
}
