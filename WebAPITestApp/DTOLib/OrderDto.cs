using System;
using System.Collections.Generic;

namespace DTOLib
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime OrderedDate { get; set; }

        public string UserFirstName { get; set; }

        public ICollection<ProductDto> ProductsDto { get; set; }

        public ICollection<int> ProductsDtoIds { get; set; }

    }
}
