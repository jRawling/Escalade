using Escalade.Web.Public.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Escalade.Web.Public.Identity
{
    public class UserStore : UserStore<ApplicationUser>
    {
        public UserStore(IdentityErrorDescriber describer = null) : base(describer) { }
    }

    public class UserStore<TUser> : UserStore<TUser, IdentityRole<Guid>>
        where TUser : IdentityUser<Guid>, new()
    {
        public UserStore(IdentityErrorDescriber describer = null) : base(describer) { }
    }

    public class UserStore<TUser, TRole> : UserStore<TUser, TRole, Guid>
        where TUser : IdentityUser<Guid>, new()
        where TRole : IdentityRole<Guid>, new()
    {
        public UserStore(IdentityErrorDescriber describer = null) : base(describer)
        { }
    }

    public class UserStore<TUser, TRole, TKey> 
        //IUserLoginStore<TUser>, -- for facebook login, etc
     //   IUserRoleStore<TUser>,
      //  IUserClaimStore<TUser>,
      //  IUserPasswordStore<TUser>,
      //  IUserSecurityStampStore<TUser>,
      //  IUserEmailStore<TUser>,
      //  IUserLockoutStore<TUser>,
      //  IUserPhoneNumberStore<TUser>,
      //  IQueryableUserStore<TUser>,
      //  IUserTwoFactorStore<TUser>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        public UserStore(IdentityErrorDescriber describer = null)
        {
            ErrorDescriber = describer ?? new IdentityErrorDescriber();
        }

        private bool isDisposed;

        public IdentityErrorDescriber ErrorDescriber { get; set; }

        public virtual string ConvertIdToString(TKey id)
        {
            if (id.Equals(default(TKey)))
            {
                return null;
            }
            return id.ToString();
        }

        public virtual TKey ConvertIdFromString(string id)
        {
            if (id == null)
            {
                return default(TKey);
            }
            return (TKey)Convert.ChangeType(id, typeof(TKey));
        }

        #region IUserStore

        public Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(ConvertIdToString(user.Id));
        }

        public Task<string> GetUserNameAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(TUser user, string normalizedName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            user.NormalizedUserName = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            user.UserName = userName;
            return Task.FromResult(0);
        }

        public Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
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

        private static void ThrowIfUserNull(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        #endregion IUserStore

        #region IUserPasswordStore

        public Task SetPasswordHashAsync(TUser user, string passwordHash, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            ThrowIfUserNull(user);
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.PasswordHash != null);
        }

        #endregion IUserPasswordStore
    }
}