using Escalade.Application.UserSession.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escalade.Application.UserSession
{
    public interface IUserSession
    {
        IDictionary<int, string> GetCountries();
        IDictionary<int, string> GetGenders();
        Task<User> FindByIdAsync(Guid guid);
        Task<User> FindByNameAsync(string normalisedUserName);
        Task<User> FindByEmailAsync(string normalisedEmail);
        void CreateAsync(User user);
    }
}