using System.Collections.Generic;

namespace DTOLib.DatabaseModels
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Costs { get; set; }
        public ICollection<OrderDto> OrderProduct { get; set; }
    }
}
