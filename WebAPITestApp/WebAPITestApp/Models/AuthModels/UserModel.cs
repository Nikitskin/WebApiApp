using System;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace WebAPITestApp.Models.AuthModels
{
    public class UserModel : IUser
    {
        [JsonIgnore]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [JsonIgnore]
        public DateTime LastPasswordChangedDate { get; set; }
    }
}
