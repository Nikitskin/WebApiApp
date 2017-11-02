using System.Collections.Generic;
using WebAPITestApp.Models.OrderControllers;

namespace WebAPITestApp.Models.ProductControllers
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public double Costs { get; set; }

        public ICollection<OrderModel> Orders { get; set; }
    }
}
