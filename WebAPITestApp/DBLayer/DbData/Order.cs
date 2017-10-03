using System.ComponentModel.DataAnnotations;

namespace DBLayer.DbData
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string ProductName { get; set; }                   
        public double Value { get; set; }
        public string OrderedDate { get; set; }
    }
}
