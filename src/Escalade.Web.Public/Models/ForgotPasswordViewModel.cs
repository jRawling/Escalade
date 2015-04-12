using System.ComponentModel.DataAnnotations;
using Dto = Escalade.Application.UserSession.Dto;

namespace Escalade.Web.Public.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage ="Please enter your email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}