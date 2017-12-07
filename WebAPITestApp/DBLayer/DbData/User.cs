using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebAPITestApp.DBLayer.DbData
{
    public class User : IdentityUser
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        public override string UserName { get; set; }

        //public string Password { get; set; }

        public DateTime LastPasswordChangedDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}