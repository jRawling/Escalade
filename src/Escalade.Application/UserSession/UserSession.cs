using Escalade.Application.UserSession.Dto;
using Escalade.Core;
using Escalade.Domain.Identity;
using Escalade.Domain.Model;
using Escalade.Domain.Model.Validation;
using Escalade.Domain.Persistence;
using Escalade.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escalade.Application.UserSession
{
    public class UserSession : IUserSession
    {
        private readonly IUserRepository userRepository;
        private readonly IEmailGateway emailGateway;

        public UserSession(IUserRepository userRepository, IEmailGateway emailGateway)
        {
            if (userRepository == null) { throw new ArgumentNullException(nameof(userRepository)); }
            if (emailGateway == null) { throw new ArgumentNullException(nameof(emailGateway)); }
            this.userRepository = userRepository;
            this.emailGateway = emailGateway;
        }

        public Task<RegistrationResult> RegisterLocal(CreateUserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResult> RegisterLocal(CreateUserDto createUserDto, string passwordHash)
        {
            throw new NotImplementedException();
            // var user = new User(createUserDto.Username, createUserDto.Email, passwordHash, createUserDto.FirstName, createUserDto.LastName);
            // ValidationResult result = await new UserValidator(userRepository).ValidateAsync(user);

            // if (result.Succeeded)
            // {
            //     await userRepository.CreateAsync(user);
            ////     string token = Guid.NewGuid().ToString().ToUpper();
            // //    await emailGateway.SendEmailVerification(user, token);
            //     return RegistrationResult.Success;
            // }
            // else
            // {
            //     var errors = result.Errors.Select(e => new UserCreationError() { Code = e.Code, Description = e.Description }).ToArray();
            //     return RegistrationResult.Failed(errors);
            // }
        }

        public async Task<UserDto> FindByEmailAsync(string email)
        {
            var user = await userRepository.FindByEmailAsync(Entity.Normalise(email));
            return user == null ? null : new UserDto(user);
        }

        public async Task<UserDto> FindByIdAsync(Guid userId)
        {
            var user = await userRepository.FindByIdAsync(userId);
            return user == null ? null : new UserDto(user);
        }

        public async Task<UserDto> FindByUsernameAsync(string username)
        {
            var user = await userRepository.FindByNameAsync(Entity.Normalise(username));
            return user == null ? null : new UserDto(user);
        }

        public async Task<UserDto> CreateUserTempAsync(CreateUserDto createUserDto, string passwordHash)
        {
            var user = new User(createUserDto.Username, createUserDto.Email, passwordHash);
            await userRepository.CreateAsync(user);
        //    await emailGateway.SendEmailVerification(user, emailConfirmationToken);
            return new UserDto(await userRepository.FindByIdAsync(user.Id));
        }

        public async Task SendEmailVerificationCode(Guid userId, string confirmationToken)
        {
            var user = await userRepository.FindByIdAsync(userId);
            await emailGateway.SendEmailVerificationAsync(user, confirmationToken);
        }

        public async Task ConfirmEmail(Guid userId)
        {
            var user = await userRepository.FindByIdAsync(userId);
            user.ConfirmEmail();
            await userRepository.UpdateAsync(user);
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