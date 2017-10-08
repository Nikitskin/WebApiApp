using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBLayer.DbData
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description  { get; set; }
        public double Costs { get; set; }
        [NotMapped]
        public ICollection<Order> Orders { get; set; }
    }
}