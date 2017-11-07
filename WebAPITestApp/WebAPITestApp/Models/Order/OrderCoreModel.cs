using System;
using System.Collections.Generic;
using WebAPITestApp.Models.Product;

namespace WebAPITestApp.Models.Order
{
    public class OrderCoreModel
    {
        public DateTime OrderedDate { get; set; }

        public ICollection<int> ProductsIds { get; set; }
    }
}
