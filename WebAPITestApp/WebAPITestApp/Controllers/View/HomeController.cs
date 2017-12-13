using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.Web.Infrastructure;
using WebAPITestApp.Web.Infrastructure.Attributes;
using WebAPITestApp.Web.Models.AuthModels;

namespace WebAPITestApp.Web.Controllers.View
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        //todo remove this
        private readonly SignInManager<User> _signInManager;

        public HomeController(IUserService userService, SignInManager<User> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateModel]
        [AllowAnonymous]
        public async Task<ActionResult> Index(UserModel user)
        {
            var result = await _userService.Authenticate(user);
            if (result !=null)
            {
                //todo refactor if works
                //this.SignIn(ClaimsPrincipal.Current, )
                return RedirectToAction("AfterLogin", "Home");
            }
            ModelState.AddModelError("", "Wrong username or password");
            ViewBag.Message = "Wrong username or password";
            return View(user);
        }

        [Route("AfterLogin")]
        public ActionResult AfterLogin()
        {
            return View();
        }

        public async Task<ActionResult> LogOff()
        {
            await _userService.LogOff();
            return RedirectToAction("Index");
        }

    }
}
