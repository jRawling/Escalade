using Escalade.Core;
using Escalade.Domain.Model;
using System;

namespace Escalade.Application.UserSession
{
    public static class MappingExtentions
    {
        public static Dto.User MapToDto(this User user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            Dto.User dtoUser = new Dto.User();

            dtoUser.CountryId = (int)user.Country;
            dtoUser.Email = user.Email;
            dtoUser.EmailConfirmed = user.EmailConfirmed;
            dtoUser.Id = user.Id;
            dtoUser.Username = user.Username;


            return dtoUser;
        }

        public static User MapToDomain(this Dto.User user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            User  domainUser = new User(user.Email, user.Username, user.FirstName, user.LastName, (Country)user.CountryId, (Gender)user.GenderId);
            return domainUser;
        }
    }
}