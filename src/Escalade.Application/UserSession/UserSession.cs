using Escalade.Core;
using System;
using System.Collections.Generic;
using Escalade.Application.UserSession.Dto;
using System.Threading.Tasks;
using Escalade.Domain.Persistence;

namespace Escalade.Application.UserSession
{
    public class UserSession : IUserSession
    {
        private readonly IUserRepository userRepository;

        public UserSession(IUserRepository userRepository)
        {
            if (userRepository == null) { throw new ArgumentNullException(nameof(userRepository)); }
            this.userRepository = userRepository;
        }

        public async void CreateAsync(User user)
        {
            await userRepository.CreateAsync(user.MapToDomain());
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await userRepository.FindByEmailAsync(email.ToLowerInvariant());
            return user == null ? null : user.MapToDto();
        }

        public async Task<User> FindByIdAsync(Guid guid)
        {
            var user = await userRepository.FindByIdAsync(guid);
            return user == null ? null : user.MapToDto();
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            var user = await userRepository.FindByNameAsync(userName.ToLowerInvariant());
            return user == null ? null : user.MapToDto();
        }

        #region Lookup

        public IDictionary<int, string> GetCountries()
        {
            Dictionary<int, string> countries = new Dictionary<int, string>();

            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                countries.Add((int)country, country.GetDescription());
            }

            return countries;
        }

        public IDictionary<int, string> GetGenders()
        {
            Dictionary<int, string> genders = new Dictionary<int, string>();

            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            {
                genders.Add((int)gender, gender.GetDescription());
            }

            return genders;
        }

        #endregion Lookup
    }
}