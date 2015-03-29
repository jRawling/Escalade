using Escalade.Domain.Model;
using System;
using System.Threading.Tasks;

namespace Escalade.Domain.Persistence
{
    public interface IUserRepository
    {
        Task<User> FindByNameAsync(string normalisedUserName);
        Task<User> FindByIdAsync(Guid userId);
        Task<User> FindByEmailAsync(string normalisedEmail);
        Task CreateAsync(User user);
    }
}