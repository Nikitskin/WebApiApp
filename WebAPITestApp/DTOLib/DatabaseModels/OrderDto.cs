using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DTOLib.DatabaseModels
{
    [JsonObject(IsReference = true)]
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
