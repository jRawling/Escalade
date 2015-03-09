using System;

namespace Escalade.Domain.Model
{
    public class User : Entity
    {
        public User(string firstName, string lastName, string location)
        {
            FirstName = firstName;
            LastName = lastName;
            Location = location;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string NormalizedEmail { get; private set; }
        public string NormalizedUserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string SecurityStamp { get; private set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }

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