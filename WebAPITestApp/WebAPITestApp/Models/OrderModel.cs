using System;
using System.Collections.Generic;

namespace WebAPITestApp.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }
        //todo shall i create a buffer class ProducetOrder that will not contain link to itself?
        public ICollection<ProductModel> Products { get; set; }
    }
}
