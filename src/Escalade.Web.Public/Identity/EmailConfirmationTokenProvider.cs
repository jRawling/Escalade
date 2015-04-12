using Escalade.Web.Public.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Security.DataProtection;
using Microsoft.Framework.OptionsModel;
using System;

namespace Escalade.Web.Public.Identity
{
    public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public EmailConfirmationTokenProviderOptions()
        {
            Name = "EmailConfirmationTokenProvider";
            TokenLifespan = new TimeSpan(7, 0, 0, 0);
        }
    }

    public class EmailConfirmationTokenProvider : DataProtectorTokenProvider<ApplicationUser>
    {
        public EmailConfirmationTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<EmailConfirmationTokenProviderOptions> options) 
            : base(dataProtectionProvider, options)
        {
        }
    }
}