using Escalade.Domain.Model;
using System;

namespace Escalade.Application.UserSession.Dto
{
    public class UserDto
    {
        public UserDto()
        { }

        public UserDto(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            NormalisedEmail = user.NormalisedEmail;
            NormalisedUsername = user.NormalisedUsername;
            IsEmailConfirmed = user.IsEmailConfirmed;
            FirstName = user.FirstName;
            LastName = user.LastName;
            PasswordHash = user.PasswordHash;
            SecurityStamp = user.SecurityStamp;
            
        }

        public Guid Id { get; }
        public string Username { get; set; }
        public string NormalisedUsername { get; }
        public string Email { get; set; }
        public string NormalisedEmail { get; }
        public bool IsEmailConfirmed { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public Guid SecurityStamp { get; set; }
    }
}