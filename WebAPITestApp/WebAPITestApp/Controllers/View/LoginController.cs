using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITestApp.Infrastructure;
using WebAPITestApp.Models.AuthModels;


namespace WebAPITestApp.Controllers.View
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login() => View();

        //TODO is it right?
        [HttpPost]
        public async Task<IActionResult> Login(UserModel user)
        {
            var result = await _userService.GetToken(user);
            if (result != null)
            {
                return RedirectToAction("AfterLogin", new { result });
            }
            ViewBag.Message = "Wrong username or password";
            return View(user);
        }

        
        [Route("AfterLogin")]
        public ActionResult AfterLogin(string result)
        {
            ViewBag.Result = result;
            return View();
        }
    }
}
