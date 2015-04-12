using Escalade.Web.Public.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Security.DataProtection;
using Microsoft.Framework.OptionsModel;
using System;

namespace Escalade.Web.Public.Identity
{
    public class ResetPasswordTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public ResetPasswordTokenProviderOptions()
        {
            Name = "ResetPasswordTokenProvider";
            TokenLifespan = new TimeSpan(0, 0, 30, 0);
        }
    }

    public class ResetPasswordTokenProvider : DataProtectorTokenProvider<ApplicationUser>
    {
        public ResetPasswordTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<ResetPasswordTokenProviderOptions> options) 
            : base(dataProtectionProvider, options)
        {
        }
    }
}