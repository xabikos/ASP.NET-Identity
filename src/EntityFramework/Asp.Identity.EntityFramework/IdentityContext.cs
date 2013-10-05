using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;

namespace Asp.Identity.EntityFramework
{
    /// <summary>
    /// Context class that handles the data access for all entities for identity 
    /// </summary>
    public class IdentityContext : DbContext
    {

        /// <summary>
        /// Public constructor just to pass the connection name
        /// </summary>
        /// <param name="connection"></param>
        public IdentityContext(string connection) : base(connection)
        {}

        /// <summary>
        /// The DbSet for Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// The DbSet for User management
        /// </summary>
        public DbSet<UserManagement> UserManagement { get; set; }

        /// <summary>
        /// The DbSet for User claims
        /// </summary>
        public DbSet<UserClaim> UserClaims { get; set; }

        /// <summary>
        /// The DbSet for User secrets
        /// </summary>
        public DbSet<UserSecret> UserSecrets { get; set; }

        /// <summary>
        /// The DbSet for User Logins
        /// </summary>
        public DbSet<UserLogin> UserLogins { get; set; }

        /// <summary>
        /// The DbSet for Roles
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// The DbSet for User Roles
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// The DbSet for Tokens
        /// </summary>
        public DbSet<Token> Tokens { get; set; }


        #region Overridden methods--------------------------------------------------

        /// <summary>
        /// <see cref="DbContext.ValidateEntity"/>
        /// </summary>
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry,
            IDictionary<object, object> items)
        {
            if(entityEntry != null && entityEntry.State == EntityState.Added)
            {
                // Validation for duplicate email
                UserBase user = entityEntry.Entity as UserBase;
                if(user != null)
                {
                    if(Users.Any(u => u.Email.ToUpper() == user.Email.ToUpper()))
                    {
                        return new DbEntityValidationResult(entityEntry, new List<DbValidationError>())
                        {
                            ValidationErrors =
                            {
                                new DbValidationError("User",
                                    string.Format(CultureInfo.CurrentCulture, "Duplicate Email. Email: {0}", user.Email))
                            }
                        };
                    }
                }
            }

            return base.ValidateEntity(entityEntry, items);
        }

        /// <summary>
        /// <see cref="DbContext.OnModelCreating"/>
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new TokenConfiguration());
            modelBuilder.Configurations.Add(new UserClaimConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserLoginConfiguration());
            modelBuilder.Configurations.Add(new UserManagementConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new UserSecretConfiguration());
        }

        #endregion
    }
}