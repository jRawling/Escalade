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
            if (userManager == null) { throw new ArgumentNullException(nameof(userManager)); }
            if (signInManager == null) { throw new ArgumentNullException(nameof(signInManager)); }
            this.userManager = userManager;
            this.signInManager = signInManager;
            SetPasswordOptions();
            SetUserOptions();
        }

        /// <summary>
        /// Set options for password validation.
        /// </summary>
        private void SetPasswordOptions()
        { 
            userManager.Options.Password.RequiredLength = 6;
            userManager.Options.Password.RequireDigit = false;
            userManager.Options.Password.RequireLowercase = false;
            userManager.Options.Password.RequireNonLetterOrDigit = false;
            userManager.Options.Password.RequireUppercase = false;
        }

        private void SetUserOptions()
        {
            userManager.Options.User.RequireUniqueEmail = true;
        }

        [Route("register")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = model.CreateUser();
                var result = await userManager.CreateAsync(user, model.Password, Context.RequestAborted);
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

            return View(model);
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
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}