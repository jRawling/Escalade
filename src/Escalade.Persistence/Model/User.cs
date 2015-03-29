using System;

namespace Escalade.Persistence.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string NormalisedUsername { get; set; }
        public string Email { get; set; }
        public string NormalisedEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string Location { get; set; }
        public int CountryId { get; set; }
        public int GenderId { get; set; }
    }
}