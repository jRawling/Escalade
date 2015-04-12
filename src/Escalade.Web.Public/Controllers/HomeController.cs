using Microsoft.AspNet.Mvc;
using System;

namespace Escalade.Web.Public.Controllers
{
    public class HomeController : AuthorisedController
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        [Route("privacy")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("terms")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Terms()
        {
            return View();
        }
    }
}