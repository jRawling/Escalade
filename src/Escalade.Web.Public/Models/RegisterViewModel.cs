using System.ComponentModel.DataAnnotations;
using Dto = Escalade.Application.UserSession.Dto;

namespace Escalade.Web.Public.Models
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        { }

        public RegisterUserModel User { get; set; }
    }

    public class RegisterUserModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}