using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace WebAPITestApp.Models.AuthModels
{
    public class UserModel : IUser
    {
        [JsonIgnore]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [JsonIgnore]
        public DateTime LastPasswordChangedDate { get; set; }

    }
}
