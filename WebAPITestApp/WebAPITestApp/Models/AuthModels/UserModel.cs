using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebAPITestApp.Web.Models.AuthModels
{
    public class UserModel 
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
