using Escalade.Application.UserSession.Dto;
using Microsoft.AspNet.Identity;
using System;

namespace Escalade.Web.Public.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public ApplicationUser()
        {  }

        public ApplicationUser(UserDto user) : base(user.Username)
        {
            Email = user.Email;
            EmailConfirmed = user.IsEmailConfirmed;
            Id = user.Id;
            UserName = user.Username;
            NormalizedEmail = user.NormalisedEmail;
            NormalizedUserName = user.NormalisedUsername;
            SecurityStamp = user.SecurityStamp.ToString();
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}