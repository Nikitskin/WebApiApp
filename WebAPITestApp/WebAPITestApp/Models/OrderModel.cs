using System;
using System.Collections.Generic;

namespace WebAPITestApp.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }
        public ICollection<ProductModel> Products { get; set; }
    }
}
