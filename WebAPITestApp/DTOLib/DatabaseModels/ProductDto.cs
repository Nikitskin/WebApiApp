using System.Collections.Generic;
using Newtonsoft.Json;

namespace DTOLib.DatabaseModels
{
    [JsonObject(IsReference = true)]
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Costs { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
    }
}
