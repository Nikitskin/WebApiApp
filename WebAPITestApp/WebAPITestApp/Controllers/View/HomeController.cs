using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPITestApp.Web.Infrastructure;
using WebAPITestApp.Web.Infrastructure.Attributes;
using WebAPITestApp.Web.Models.AuthModels;

namespace WebAPITestApp.Web.Controllers.View
{
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult> Index(UserModel user)
        {
            var result = await _userService.Authenticate(user);
            if (result.Succeeded)
            {
                await _userService.Authenticate(user);
                return RedirectToAction("AfterLogin", user);
            }
            ModelState.AddModelError("", "Wrong username or password");
            ViewBag.Message = "Wrong username or password";
            return View(user);
        }
        
        [Route("AfterLogin")]
        [Authorize]
        public ActionResult AfterLogin(UserModel model)
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
