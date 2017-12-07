using System;
using System.Collections.Generic;

namespace WebAPITestApp.DTOLib
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime OrderedDate { get; set; }

        public string UserFirstName { get; set; }

        public ICollection<ProductDto> Products { get; set; }

        public ICollection<int> ProductsIds { get; set; }

    }
}
