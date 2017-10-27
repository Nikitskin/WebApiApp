using System.Collections.Generic;

namespace WebAPITestApp.Models
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
