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
        // TODO You should use only interfaces here.
        //Otherwise what's the point of interfaces if you cast them to their implementations?
        private UnitOfWork _unitOfWork;


        // TODO remove default constructor
        public OrdersController()
        {

        }

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        [HttpGet]
        public async Task<List<Order>> Get()
        {
            // TODO You should understand that it's not good option to work with data in controllers.
            //You should have separate layer for business logic that works with data.
            // TODO It's better to create separate response models and map db data to this models every time. Automapper nuget will help with it.
            return await _unitOfWork.Orders.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await _unitOfWork.Orders.GetItem(id);
        }

        [HttpPost]
        public void Post([FromBody]Order value)
        {
            _unitOfWork.Orders.Update(value);
        }

        [HttpPut("{id}")]
        public void Put([FromBody]Order value)
        {
            _unitOfWork.Orders.Create(value);
            // TODO You created an item, but you didn't commit transaction.
            // You should call SaveChanges method in the end of business transaction
        }

        [HttpDelete("{id}")]
        public void Delete(Order order)
        {
            _unitOfWork.Orders.Delete(order);
        }
    }
}
