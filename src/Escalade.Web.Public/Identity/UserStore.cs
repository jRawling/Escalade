using Escalade.Domain.Model;
using Escalade.Domain.Persistence;
using Escalade.Web.Public.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Escalade.Web.Public.Identity
{ 
    public class UserStore :
        IUserPasswordStore<ApplicationUser>,
        IUserSecurityStampStore<ApplicationUser>,
        IUserEmailStore<ApplicationUser>,
        IUserStore<ApplicationUser>
        // IUserRoleStore<TUser>,
        //  IUserClaimStore<TUser>,
        //  IUserLockoutStore<TUser>,
        //  IUserPhoneNumberStore<TUser>,
        //  IQueryableUserStore<TUser>,
        //  IUserTwoFactorStore<TUser>,
        //  IUserLoginStore<TUser> -- for facebook login, etc

    {
        public UserStore(IUserRepository userRepository, IdentityErrorDescriber describer = null)
        {
            if(userRepository == null) { throw new ArgumentNullException(nameof(userRepository)); }
            this.userRepository = userRepository;
            ErrorDescriber = describer ?? new IdentityErrorDescriber();
        }

        private bool isDisposed = false;
        private readonly IUserRepository userRepository;

        public IdentityErrorDescriber ErrorDescriber { get; set; }

        private string ConvertIdToString(Guid id)
        {
            if (id.Equals(default(Guid)))
            {
                return null;
            }
            return id.ToString();
        }

        private Guid ConvertIdFromString(string id)
        {
            if (id == null)
            {
                return default(Guid);
            }
            return (Guid)Convert.ChangeType(id, typeof(Guid));
        }

        private ApplicationUser CreateApplicationUser(User user)
        {
            if (user != null)
            {
                return new ApplicationUser(user);
            }

            return null;
        }

        #region IUserStore

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            // add user to persistence
            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            User user = await userRepository.FindByIdAsync(ConvertIdFromString(userId), cancellationToken);
            return CreateApplicationUser(user);
        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            User user = await userRepository.FindByNameAsync(normalizedUserName, cancellationToken);
            return CreateApplicationUser(user);
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(ConvertIdToString(user.Id));
        }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            user.NormalizedUserName = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            user.UserName = userName;
            return Task.FromResult(0);
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            isDisposed = true;
        }

        private void ThrowIfDisposed()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        private static void ThrowIfUserNull(ApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        #endregion IUserStore

        #region IUserPasswordStore

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.PasswordHash != null);
        }

        #endregion IUserPasswordStore

        #region IUserEmailStore

        public Task SetEmailAsync(ApplicationUser user, string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            user.EmailConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            User user = await userRepository.FindByEmailAsync(normalizedEmail, cancellationToken);
            return CreateApplicationUser(user);
        }

        public Task<string> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(user.NormalizedEmail);
        }

        public Task SetNormalizedEmailAsync(ApplicationUser user, string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            user.NormalizedEmail = normalizedEmail;
            return Task.FromResult(0);
        }

        #endregion IUserEmailStore

        #region IUserSecurityStampStore

        public Task SetSecurityStampAsync(ApplicationUser user, string stamp, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(user.SecurityStamp);
        }

        #endregion IUserSecurityStampStore
    }
}