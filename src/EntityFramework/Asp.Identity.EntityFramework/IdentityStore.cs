using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Asp.Identity.EntityFramework
{
    /// <summary>
    /// The store that handles all the interaction with the database for security (authentication and authorization)   
    /// </summary>
    public class IdentityStore : IIdentityStore
    {
        private IdentityContext _context;

        #region Constructors--------------------------------------------------------

        /// <summary>
        /// Ctor
        /// </summary>
        public IdentityStore(IdentityContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            _context = context;
            Logins = new UserLoginStore<UserLogin>(_context);
            Roles = new RoleStore<Role, UserRole>(_context);
            Secrets = new UserSecretStore<UserSecret>(_context);
            Tokens = new TokenStore<Token>(_context);
            UserClaims = new UserClaimStore<UserClaim>(_context);
            UserManagement = new UserManagementStore<UserManagement>(_context);
            Users = new UserStore<User>(_context);
        }

        #endregion

        #region IIdentityStore members----------------------------------------------

        /// <summary>
        /// <see cref="IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public async Task<IdentityResult> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                return IdentityResult.Succeeded();
            }
            catch (DbEntityValidationException ex)
            {
                return
                    IdentityResult.Failed(
                        ex.EntityValidationErrors.SelectMany(ve => ve.ValidationErrors.Select(e => e.ErrorMessage))
                            .ToArray());
            }
        }

        public IUserSecretStore Secrets { get; private set; }
        public IUserLoginStore Logins { get; private set; }
        public IUserStore Users { get; private set; }
        public IUserManagementStore UserManagement { get; private set; }
        public IRoleStore Roles { get; private set; }
        public IUserClaimStore UserClaims { get; private set; }
        public ITokenStore Tokens { get; private set; }

        #endregion

        /// <summary>
        /// Helper method that cleans up all the resources
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
            }
            _context = null;
            Logins = null;
            Roles = null;
            Secrets = null;
            Tokens = null;
            UserClaims = null;
            UserManagement = null;
            Users = null;
        }

    }
}