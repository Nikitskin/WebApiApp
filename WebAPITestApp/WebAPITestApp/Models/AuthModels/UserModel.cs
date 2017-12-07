using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace WebAPITestApp.Web.Models.AuthModels
{
    /// <inheritdoc />
    /// <summary>
    /// Basic user model
    /// </summary>
    public class UserModel : IUser
    {
        /// <inheritdoc />
        /// <summary>
        /// Id to find user in storage
        /// </summary>
        [JsonIgnore]
        public string Id { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// User name 
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Users password 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Last time when password was changed by user
        /// </summary>
        [JsonIgnore]
        public DateTime LastPasswordChangedDate { get; set; }

    }
}
