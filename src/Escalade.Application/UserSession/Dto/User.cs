using System;

namespace Escalade.Application.UserSession.Dto
{
    public class User
    {
        public string Username { get; set; }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public int GenderId { get; set; }
        public string PasswordHash { get; set; }
    }
}