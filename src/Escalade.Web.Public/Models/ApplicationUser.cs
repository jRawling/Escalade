using Escalade.Application.UserSession.Dto;
using Microsoft.AspNet.Identity;
using System;

namespace Escalade.Web.Public.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public ApplicationUser()
        {  }

        public ApplicationUser(User user) : base(user.Username)
        {
            Email = user.Email;
            EmailConfirmed = user.EmailConfirmed;
            Id = user.Id;
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User MapToDto()
        {
            return new User()
            {
                Email = Email,
                EmailConfirmed =  EmailConfirmed,
                FirstName = FirstName,
                Id = Id,
                LastName = LastName,
                Username = UserName
            };
        }
    }
}