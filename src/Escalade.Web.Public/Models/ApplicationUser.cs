using Escalade.Domain.Model;
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
    }
}