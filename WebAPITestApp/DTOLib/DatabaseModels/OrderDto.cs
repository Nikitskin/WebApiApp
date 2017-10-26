using System;
using System.Collections.Generic;

namespace DTOLib.DatabaseModels
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }
        public ICollection<ProductDto> OrderProduct { get; set; }
    }
}
