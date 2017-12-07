﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITestApp.Web.Infrastructure;
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

        public ActionResult Login()
        {
            return View();
        } 

        //TODO is it right?
        [HttpPost]
        public async Task<ActionResult> Login(UserModel user)
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