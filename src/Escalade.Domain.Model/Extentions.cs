using System;
using Dto = Escalade.Persistence.Model;

namespace Escalade.Domain.Model
{
    public static class ModelExtentions
    {
        public static User AsDomain(this Dto.User user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            return new User(user);
        }

        public static Dto.User AsDto(this User user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            Dto.User dtoUser = new Dto.User();

            dtoUser.Email = user.Email;
            dtoUser.IsEmailConfirmed = user.IsEmailConfirmed;
            dtoUser.FirstName = user.FirstName;
            dtoUser.Id = user.Id;
            dtoUser.LastName = user.LastName;
            dtoUser.NormalisedEmail = user.NormalisedEmail;
            dtoUser.NormalisedUsername = user.NormalisedUsername;
            dtoUser.PasswordHash = user.PasswordHash;
            dtoUser.SecurityStamp = user.SecurityStamp;
            dtoUser.Username = user.Username;
            dtoUser.CountryId = (int)user.Country;
            dtoUser.GenderId = (int)user.Gender;

            return dtoUser;
        }

        /// <summary>
        /// Update this!!!!
        /// </summary>
        /// <param name="dtoUser"></param>
        /// <param name="domainUser"></param>
        public static void MapFrom(this Dto.User dtoUser, User domainUser)
        {
            dtoUser.IsEmailConfirmed = domainUser.IsEmailConfirmed;
            dtoUser.SecurityStamp = domainUser.SecurityStamp;
        }
    }
}