using Escalade.Web.Public.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Escalade.Web.Public.Identity
{
    public class RoleStore : RoleStore<IdentityRole<Guid>>
    {
        public RoleStore(IdentityErrorDescriber describer = null) : base(describer) { }
    }

    public class RoleStore<TRole> : RoleStore<TRole, Guid>
        where TRole : IdentityRole<Guid>, new()
    {
        public RoleStore(IdentityErrorDescriber describer = null) : base(describer)
        { }
    }

    public class RoleStore<TRole, TKey> :
        IRoleStore<TRole>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        public RoleStore(IdentityErrorDescriber describer = null)
        {
            ErrorDescriber = describer ?? new IdentityErrorDescriber();
        }

        private bool isDisposed = false;

        public IdentityErrorDescriber ErrorDescriber { get; set; }

        #region IRoleStore

        public Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<TRole> FindByIdAsync(string roleId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<TRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
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

        private static void ThrowIfRoleNull(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
        }

        #endregion IRoleStore
    }
}