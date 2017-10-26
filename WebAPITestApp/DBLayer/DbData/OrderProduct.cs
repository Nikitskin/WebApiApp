using System.ComponentModel.DataAnnotations;

namespace DBLayer.DbData
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}