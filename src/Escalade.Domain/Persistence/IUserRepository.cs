using Escalade.Domain.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Escalade.Domain.Persistence
{
    public interface IUserRepository
    {
        Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken);
        Task<User> FindByIdAsync(Guid userId, CancellationToken cancellationToken);
    }
}