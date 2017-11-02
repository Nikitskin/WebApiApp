using Microsoft.AspNet.Identity;

namespace WebAPITestApp.Models.AuthModels
{
    public class UserModel : IUser
    {
        public string Id { get; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
