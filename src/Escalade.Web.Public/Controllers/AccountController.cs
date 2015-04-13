using Escalade.Application;
using Dto = Escalade.Application.UserSession.Dto;
//using Escalade.Gateway.Email;
using Escalade.Web.Public.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Principal;

namespace Escalade.Web.Public.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUserSession userSession;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserSession userSession)
        {
            if(userSession == null) { throw new ArgumentNullException(nameof(userSession)); }
            if (userManager == null) { throw new ArgumentNullException(nameof(userManager)); }
            if (signInManager == null) { throw new ArgumentNullException(nameof(signInManager)); }
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userSession = userSession;
            SetPasswordOptions();
            SetUserOptions();
            SetProviderOptions();
        }

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

        private void SetProviderOptions()
        {
            userManager.Options.EmailConfirmationTokenProvider = "EmailConfirmationTokenProvider";
            userManager.Options.ChangeEmailTokenProvider = "EmailConfirmationTokenProvider";
            userManager.Options.PasswordResetTokenProvider = "ResetPasswordTokenProvider";
        }

        [Route("register")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
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
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    Email = model.User.EmailAddress,
                    UserName = model.User.Username
                };

                // --- get rid of this once hashing and token generation logic is in domain - call usersession instead
                var result = await userManager.CreateAsync(applicationUser, model.User.Password, Context.RequestAborted);
                if (result.Succeeded)
                {     
                    // --- get rid of this once hashing and token generation logic is in domain
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(applicationUser, Context.RequestAborted);
                    await userSession.SendEmailVerificationCode(applicationUser.Id, code);
                    // ---
                    await signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }

            return View(model);
        }

        [Route("resend-email-confirmation")]
        [HttpGet]
        public async Task ResendEmailVerification()
        {
            var user = await GetCurrentUserAsync();
            var code = await userManager.GenerateEmailConfirmationTokenAsync(user, Context.RequestAborted);
            await userSession.SendEmailVerificationCode(user.Id, code);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("confirm-email")]
        public async Task<ActionResult> ConfirmEmail(string email, string code)
        {
            if (email == null || code == null) { return View("Error"); }

            ApplicationUser user = new ApplicationUser(await userSession.FindByEmailAsync(email));
            if (user == null) { return View("InvalidToken"); }

            if(user.EmailConfirmed)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await userManager.ConfirmEmailAsync(user, code, Context.RequestAborted);
            return result.Succeeded ? View("EmailConfirmed") : View("InvalidToken");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("forgot-password")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("forgot-password")]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userSession.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Sorry, that email address is not registered with us.");
                    return View(model);
                }
                else
                {

                    ApplicationUser applicationUser = new ApplicationUser(user);
                    var code = await userManager.GeneratePasswordResetTokenAsync(applicationUser, Context.RequestAborted);
                    await userSession.SendPasswordResetInstructions(user.Id, code);
                    return View("ForgotPasswordConfirmation");
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

            throw new NotImplementedException();
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

            //return View(model);
        }

        [HttpGet]
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

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await userManager.FindByIdAsync(Context.User.Identity.GetUserId(), cancellationToken: Context.RequestAborted);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}