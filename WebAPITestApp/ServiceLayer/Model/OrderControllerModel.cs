using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public class OrderControllerModel
    {
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }
        public ICollection<ProductControllerModel> OrderProduct { get; set; }
    }
}
