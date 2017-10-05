using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLayer.DbData
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        public ICollection<Product> Products { get; set; } 
    }
}
