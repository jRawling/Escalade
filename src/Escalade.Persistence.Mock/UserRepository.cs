using Escalade.Domain.Model;
using Escalade.Domain.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Escalade.Persistence.Mock
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            // mock a few users
        }

        public Task<User> FindByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByNameAsync(string username, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}