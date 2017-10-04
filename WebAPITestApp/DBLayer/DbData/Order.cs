using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLayer.DbData
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public DateTime OrderedDate { get; set; }
        public User Users { get; set; }
        public int UserId { get; set; }
    }
}
