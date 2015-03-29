using Escalade.Application.UserSession;
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
        private readonly IUserSession userSession;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserSession userSession)
        {
            if (userManager == null) { throw new ArgumentNullException(nameof(userManager)); }
            if (signInManager == null) { throw new ArgumentNullException(nameof(signInManager)); }
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userSession = userSession;
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
            RegisterViewModel model = new RegisterViewModel();
            model.SetDropdowns(userSession.GetCountries(), userSession.GetGenders());
            return View(model);
        }

        [Route("register")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = model.User.MapToApplication();
                var result = await userManager.CreateAsync(user, model.User.Password, Context.RequestAborted);
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

            model.SetDropdowns(userSession.GetCountries(), userSession.GetGenders());
            return View(model);
        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string email, string code)
        {
            if (email == null || code == null)
            {
                return View("Error");
            }

            var user = await signInManager.UserManager.FindByEmailAsync(email, Context.RequestAborted);
            if (user == null)
            {
                return View("Error");
            }
            var result = await userManager.ConfirmEmailAsync(user, code, Context.RequestAborted);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
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
            //if (ModelState.IsValid)
            //{
            //    var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            //    if (result.Succeeded)
            //    {
            //        return RedirectToLocal(returnUrl);
            //    }

            //    ModelState.AddModelError("", "Invalid username or password.");
            //    return View(model);
            //}

            // If we got this far, something failed, redisplay form
            return View(model);


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