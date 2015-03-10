using Escalade.Domain.Model;
using Escalade.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dto = Escalade.Persistence.Model;

namespace Escalade.Persistence.Mock
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            AddUsers();
        }

        private List<Dto.User> users = new List<Dto.User>();

        private void AddUsers()
        {
            Dto.User user1 = new Model.User();
            user1.Id = Guid.NewGuid();
            user1.FirstName = "Jonathan";
            user1.LastName = "Rawling";
            user1.Location = "Reading";
            user1.Email = "jonathan@rawling.me";
            user1.NormalisedEmail = user1.Email;
            user1.Username = "jrawling";
            user1.NormalisedUsername = user1.Username;
            user1.EmailConfirmed = true;

            users.Add(user1);
        }

        private User CreateUser(Dto.User user)
        {
            if(user != null)
            {
                return new User(user);
            }

            return null;
        }

        private string Normalise(string field)
        {
            return field.ToLowerInvariant();
        }

        public Task<User> FindByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            Dto.User user = users.Where(u => u.Id == userId).FirstOrDefault();
            return Task.FromResult(CreateUser(user));
        }

        public Task<User> FindByNameAsync(string username, CancellationToken cancellationToken)
        {
            Dto.User user = users.Where(u => u.NormalisedUsername.Equals(Normalise(username))).FirstOrDefault();
            return Task.FromResult(CreateUser(user));
        }

        public Task<User> FindByEmailAsync(string email, CancellationToken cancellationToken)
        {
            Dto.User user = users.Where(u => u.NormalisedEmail.Equals(Normalise(email))).FirstOrDefault();
            return Task.FromResult(CreateUser(user));
        }
    }
}