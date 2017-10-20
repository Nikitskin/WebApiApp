using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }
        public ICollection<ProductDto> OrderProduct { get; set; }
    }
}
