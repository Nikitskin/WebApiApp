using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBLayer.DbData
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        //TODO Not mapped entitis, should be relationships
        [NotMapped]
        public ICollection<Product> Products { get; set; } 
    }
}
