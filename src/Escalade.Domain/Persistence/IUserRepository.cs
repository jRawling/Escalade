using Escalade.Domain.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Escalade.Domain.Persistence
{
    public interface IUserRepository
    {
        Task<User> FindByNameAsync(string normalisedUserName, CancellationToken cancellationToken);
        Task<User> FindByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<User> FindByEmailAsync(string normalisedEmail, CancellationToken cancellationToken);
    }
}