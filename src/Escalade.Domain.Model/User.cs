using Escalade.Core;
using System;
using Dto = Escalade.Persistence.Model;

namespace Escalade.Domain.Model
{
    public class User : Entity
    {
        public User(string username, string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            UpdateUsername(username);
            UpdateEmail(email);
            UpdatePasswordHash(passwordHash);
        }

        internal User(Dto.User user)
        {
            Id = user.Id;
            Username = user.Username;
            NormalisedUsername = user.NormalisedUsername;
            Email = user.Email;
            NormalisedEmail = user.NormalisedEmail;
            IsEmailConfirmed = user.IsEmailConfirmed;
            PasswordHash = user.PasswordHash;
            SecurityStamp = user.SecurityStamp;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Country = (Country)user.CountryId;
            Gender = (Gender)user.GenderId;
        }

        public Guid Id { get; }
        public string Username { get; private set; }
        public string NormalisedUsername { get; private set; }
        public string Email { get; private set; }
        public string NormalisedEmail { get; private set; }
        public bool IsEmailConfirmed { get; private set; }
        public string PasswordHash { get; private set; }
        public Guid SecurityStamp { get; private set; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
        public Country Country { get; private set; }
        public Gender Gender { get; private set; }

        public void UpdateUsername(string username)
        {
            Username = username;
            NormalisedUsername = Normalise(username);
        }

        public void UpdateEmail(string email)
        {
            Email = email;
            NormalisedEmail = Normalise(email);
            IsEmailConfirmed = false;
        }

        public void ConfirmEmail()
        {
            IsEmailConfirmed = true;
        }

        public void UpdatePasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
            UpdateSecurityStamp();
        }

        public void UpdateCountry(Country country)
        {
            Country = country;
        }

        private void UpdateSecurityStamp()
        {
            SecurityStamp = Guid.NewGuid();
        }
    }
}