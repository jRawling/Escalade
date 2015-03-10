using System;
using Dto = Escalade.Persistence.Model;

namespace Escalade.Domain.Model
{
    public class User : Entity
    {
        public User(string username, string firstName, string lastName, string location)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Location = location;
        }

        public User(Dto.User user)
        {
            Id = user.Id;
            Username = user.Username;
            NormalisedUsername = user.NormalisedUsername;
            Email = user.Email;
            NormalisedEmail = user.NormalisedEmail;
            EmailConfirmed = user.EmailConfirmed;
            PasswordHash = user.PasswordHash;
            SecurityStamp = user.SecurityStamp;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Location = user.Location;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string NormalisedUsername { get; private set; }
        public string Email { get; private set; }
        public string NormalisedEmail { get; private set; }
        public bool EmailConfirmed { get; private set; }
        public string PasswordHash { get; private set; }
        public string SecurityStamp { get; private set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }

        public string GetFullName()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        public void UpdateUsername(string username)
        {
            Username = username;
            NormalisedUsername = Normalise(username);
        }

        public void UpdateEmail(string email)
        {
            Email = email;
            NormalisedEmail = Normalise(email);
            EmailConfirmed = false;
        }

        public void UpdatePasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
            UpdateSecurityStamp();
        }

        private void UpdateSecurityStamp()
        {
            SecurityStamp = Guid.NewGuid().ToString();
        }
    }
}