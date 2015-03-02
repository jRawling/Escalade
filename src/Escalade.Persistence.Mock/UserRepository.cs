using Escalade.Domain.Model;
using Escalade.Domain.Persistence;
using System;

namespace Escalade.Persistence.Mock
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }

        public User GetUserById(string id)
        {
            throw new NotImplementedException();
        }
    }
}