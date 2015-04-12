using Escalade.Domain.Model;
using System;

namespace Escalade.Gateway.Email
{
    internal abstract class MailMessage
    {
        public MailMessage(User user, string from)
        {
            User = user;
            From = from;
            To = user.Email;
        }

        protected User User { get; }
        public string From { get; }
        public virtual string To { get; }
        public string Subject { get; protected set; }
        public abstract string GetBodyAsHtml();
    }
}