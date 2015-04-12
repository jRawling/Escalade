using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Escalade.Domain.Model;
using Microsoft.Framework.OptionsModel;

namespace Escalade.Gateway.Email
{
    public class MailTrapGateway : EmailGateway
    {
        public MailTrapGateway(IOptions<EmailGatewayOptions> options)
            : base(options)
        { }

        public override Task SendEmailVerificationAsync(User user, string token)
        {
            string fromAddress = string.Format("{0}@{1}", "confirm", Domain);
            EmailConfirmation message = new EmailConfirmation(user, token, ConfirmationLink, fromAddress);

            var client = new SmtpClient("mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("32860a0867666ed71", "f42620e032f02f"),
                EnableSsl = true
            };

            client.Send(message.From, message.To, message.Subject, message.GetBodyAsHtml());
            return Task.FromResult(0);
        }
    }
}