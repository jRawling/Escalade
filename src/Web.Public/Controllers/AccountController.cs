using Microsoft.AspNet.Mvc;
using System;

namespace Escalade.Web.Public.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        { }

        [Route("register")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            throw new NotSupportedException();
        }

        [Route("register")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(object viewModel)
        {
            throw new NotSupportedException();
        }

        [Route("login")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            throw new NotSupportedException();
        }

        [Route("login")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(object viewModel)
        {
            throw new NotSupportedException();
        }

        [Route("login/facebook")]
        public IActionResult LoginWithFacebook()
        {
            throw new NotSupportedException();
        }

        [Route("logout")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Logout()
        {
            throw new NotSupportedException();
        }
    }
}