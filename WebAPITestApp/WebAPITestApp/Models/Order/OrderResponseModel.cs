
using System.Collections.Generic;
using WebAPITestApp.Models.Product;

namespace WebAPITestApp.Models.Order
{
    public class OrderResponseModel : OrderCoreModel
    {
        public int Id { get; set; }

        public ICollection<ProductFullModel> ProductModels { get; set; }

    }
}
