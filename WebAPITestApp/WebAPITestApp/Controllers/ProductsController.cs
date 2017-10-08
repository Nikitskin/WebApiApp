using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPITestApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // GET api/values
        // Return sql values
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> list = new List<string>()
            {
                "SQL RETURNS!!!Muhahah"
            };
            return list;
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
