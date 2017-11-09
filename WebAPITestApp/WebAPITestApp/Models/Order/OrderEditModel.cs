using System.Collections.Generic;

namespace WebAPITestApp.Models.Order
{
    public class OrderEditModel
    {

        public ICollection<int> ProductIds { get; set; }

    }
}
