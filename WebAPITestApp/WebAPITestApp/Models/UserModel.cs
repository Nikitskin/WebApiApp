using System.ComponentModel.DataAnnotations;

namespace WebAPITestApp.Models
{
    public class UserModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
