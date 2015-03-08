using Microsoft.AspNet.Identity;
using System;

namespace Escalade.Web.Public.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }
    }
}