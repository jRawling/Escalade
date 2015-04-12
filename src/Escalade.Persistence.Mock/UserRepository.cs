using Escalade.Core;
using Escalade.Domain.Model;
using Escalade.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private HashSet<Dto.User> users = new HashSet<Dto.User>(new CompareUsers());

        private void AddUsers()
        {
            Dto.User user1 = new Model.User();
            user1.Id = Guid.NewGuid();
            user1.FirstName = "Jonathan";
            user1.LastName = "Rawling";
            user1.Location = "Reading";
            user1.Email = "jonathan@rawling.me";
            user1.NormalisedEmail = user1.Email.ToLowerInvariant();
            user1.Username = "jrawling";
            user1.NormalisedUsername = user1.Username.ToLowerInvariant();
            user1.EmailConfirmed = false;
            user1.GenderId = (int)Gender.Male;
            user1.CountryId = (int)Country.UnitedKingdom;
        
            users.Add(user1);
        }

        public Task<User> FindByIdAsync(Guid userId)
        {
            Dto.User user = users.Where(u => u.Id == userId).FirstOrDefault();
            return Task.FromResult(user == null ? null : user.MapToDomain());
        }

        public Task<User> FindByNameAsync(string normalisedUsername)
        {
            Dto.User user = users.Where(u => u.NormalisedUsername.Equals(normalisedUsername)).FirstOrDefault();
            return Task.FromResult(user == null ? null : user.MapToDomain());
        }

        public Task<User> FindByEmailAsync(string normalisedEmail)
        {
            Dto.User user = users.Where(u => u.NormalisedEmail.Equals(normalisedEmail)).FirstOrDefault();
            return Task.FromResult(user == null ? null : user.MapToDomain());
        }

        public Task<User> CreateAsync(User user)
        {
            if(user == null) { throw new ArgumentNullException(nameof(user)); }
            users.Add(user.MapToDto());
            return Task.FromResult(user);
        }

        internal class CompareUsers : IEqualityComparer<Dto.User>
        {
            public bool Equals(Dto.User x, Dto.User y)
            {
                bool sameEmail = x.NormalisedEmail.Equals(y.NormalisedEmail);
                bool sameUsername = x.NormalisedUsername.Equals(y.NormalisedUsername);

                return sameEmail || sameUsername;
            }

            public int GetHashCode(Dto.User user)
            {
                return (user.NormalisedEmail + user.NormalisedUsername).GetHashCode();
            }
        }
    }
}