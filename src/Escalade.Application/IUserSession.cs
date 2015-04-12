using Escalade.Application.UserSession.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escalade.Application
{
    public interface IUserSession
    {
        IDictionary<int, string> GetCountries();
        IDictionary<int, string> GetGenders();
        Task<UserDto> FindByIdAsync(Guid userId);
        Task<UserDto> FindByUsernameAsync(string normalisedUsername);
        Task<UserDto> FindByEmailAsync(string normalisedEmail);
        //    Task<RegistrationResult> RegisterLocal(CreateUserDto user);
        //   Task<RegistrationResult> RegisterLocal(CreateUserDto createUserDto, string passwordHash);
        /// <summary>
        /// remove this as soon as password hashing and email token generation logic is moved to the domain
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passwordHash"></param>
        /// <param name="emailConfirmationToken"></param>
        /// <returns></returns>
        Task<UserDto> CreateUserTempAsync(CreateUserDto user, string passwordHash);
        Task SendEmailVerificationCode(Guid userId, string confirmationToke);

        Task ConfirmEmail(Guid id);
    }
}