using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLayer.DbData
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; } // TODO All navigation properties should be in the end of class.
        public DateTime OrderedDate { get; set; }
        public User User { get; set; } // TODO All navigation properties should be in the end of class.
        public int UserId { get; set; }
    }
}
