using System;
using System.Collections.Generic;
using WebAPITestApp.Models.Product;

namespace WebAPITestApp.Models.Order
{
    public class OrderResponseModel
    {
        public int Id { get; set; }

        public DateTime OrderedDate { get; set; }

        public ICollection<ProductFullModel> ProductModels { get; set; }

    }
}
