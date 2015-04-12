using Escalade.Domain.Model;
using Microsoft.Framework.OptionsModel;
using System;
using System.Threading.Tasks;

namespace Escalade.Gateway.Email
{
    public abstract class EmailGateway : IEmailGateway
    {
        private readonly EmailGatewayOptions options;

        public EmailGateway(IOptions<EmailGatewayOptions> options)
        {
            if (options == null) { throw new ArgumentNullException(nameof(options)); }
            this.options = options.Options;
        }

        protected string Domain { get { return options.Domain; } }
        protected string ConfirmationLink { get { return options.ConfirmationLink; } }

        public abstract Task SendEmailVerificationAsync(User user, string token);
    }
}