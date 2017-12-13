using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITestApp.Web.Infrastructure;
using WebAPITestApp.Web.Infrastructure.Attributes;
using WebAPITestApp.Web.Models.AuthModels;

namespace WebAPITestApp.Web.Controllers.View
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Register(UserModel model)
        {
            var result = await _userService.AddUser(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ViewBag.Errors = error.Description + "\n";
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
    }
}