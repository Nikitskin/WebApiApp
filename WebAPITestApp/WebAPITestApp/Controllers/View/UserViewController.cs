using Microsoft.AspNetCore.Mvc;
using WebAPITestApp.Web.Infrastructure;
using WebAPITestApp.Web.Models.AuthModels;

namespace WebAPITestApp.Web.Controllers.View
{
    public class UserViewController : Controller
    {
        private IUserService _userService;

        public UserViewController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel userModel)
        {
            var task = _userService.AddUser(userModel);
            //TODO Should it be refactored?
            task.Wait();
            RedirectToAction("ResultPage", new { task.IsFaulted });
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel userModel)
        {
            //TODO redo with identity
            var task = _userService.UpdateUser(userModel);
            //TODO Should it be refactored?
            task.Wait();
            RedirectToAction("ResultPage", new { task.IsFaulted });
            return View();
        }

        public ActionResult ResultPage(bool isFaulted)
        {
            var result = isFaulted ? "Success" : "Failure";
            ViewBag.Result = result;
            return View();
        }
    }
}