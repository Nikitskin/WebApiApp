using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLayer.DbData
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public string OrderedDate { get; set; }
    }
}
