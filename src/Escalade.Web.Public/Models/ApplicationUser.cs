using Microsoft.AspNet.Identity;
using System;

namespace Escalade.Web.Public.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string userName) : base(userName)
        {
        }
    }
}