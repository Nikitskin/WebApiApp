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
        private UnitOfWork _unitOfWork;

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
        }

        [HttpDelete("{id}")]
        public void Delete(Order order)
        {
            _unitOfWork.Orders.Delete(order);
        }
    }
}
