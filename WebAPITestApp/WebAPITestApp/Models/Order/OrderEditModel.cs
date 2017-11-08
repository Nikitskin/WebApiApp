using System.Collections.Generic;

namespace WebAPITestApp.Models.Order
{
    public class OrderEditModel : OrderCoreModel
    {
        public ICollection<int> ProductIds { get; set; }

    }
}
