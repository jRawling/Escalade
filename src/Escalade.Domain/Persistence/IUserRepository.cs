using Escalade.Domain.Model;
using System;

namespace Escalade.Domain.Persistence
{
    public interface IUserRepository
    {
        User GetUserById(string id);
    }
}