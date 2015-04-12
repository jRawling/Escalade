using Escalade.Domain.Model;
using System;
using System.Text;

namespace Escalade.Gateway.Email
{
    internal class EmailConfirmation : MailMessage
    {
        private readonly User user;
        private readonly string confirmationLink;

        public EmailConfirmation(User user, string token, string confirmationLink, string from)
            : base(user, from)
        {
            ThrowIfUserInvalid(user);
            if(string.IsNullOrEmpty(token)) { throw new ArgumentException(nameof(token)); }
            if (string.IsNullOrEmpty(confirmationLink)) { throw new ArgumentException(nameof(confirmationLink)); }
            if (string.IsNullOrEmpty(from)) { throw new ArgumentException(nameof(from)); }
            this.user = user;
            this.confirmationLink = string.Format(confirmationLink, user.NormalisedEmail, Uri.EscapeDataString(token));
            Subject = string.Format("Confirm your email", user.FirstName);
        }

        private void ThrowIfUserInvalid(User user)
        {
            if(user == null) { throw new ArgumentNullException(nameof(user)); }
            if(string.IsNullOrEmpty(user.Email)) { throw new ArgumentException(nameof(user.Email)); }
        }

        public override string GetBodyAsHtml()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Hi {0}, welcome to Hastilude!", user.Username).AppendLine();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Before you get started, please confirm your email address below:");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(confirmationLink);
            return stringBuilder.ToString();
        }
    }
}