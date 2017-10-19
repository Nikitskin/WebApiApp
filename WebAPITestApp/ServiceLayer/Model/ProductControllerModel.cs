using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public class ProductControllerModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Costs { get; set; }
        public ICollection<OrderControllerModel> OrderProduct { get; set; }
    }
}
