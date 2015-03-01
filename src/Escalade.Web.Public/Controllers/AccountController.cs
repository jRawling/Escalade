using Escalade.Web.Public.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using System;
using System.Threading.Tasks;

namespace Escalade.Web.Public.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            if (userManager == null) { throw new ArgumentNullException("userManager"); }
            if (signInManager == null { throw new ArgumentNullException("signInManager"); }

            this.userManager = userManager;
            this.signInManager = signInManager;
        }

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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser(model.UserName);
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }

            throw new NotSupportedException();
        }

        [Route("login")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            throw new NotSupportedException();
        }

        [Route("login")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(object model, string returnUrl = null)
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

        /// <summary>
        /// Add errors to the ModelState.
        /// </summary>
        /// <param name="result">The result of an identity operation.</param>
        private void AddErrors(IdentityResult result)
        {
            foreach(string error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }
    }
}