using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPITestApp.DBLayer.DbData
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime LastPasswordChangedDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}