using Microsoft.AspNet.Mvc;
using System;

namespace Escalade.Web.Public.Controllers
{
    public class HomeController : BaseController
    {
        [Route("/")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("privacy")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}