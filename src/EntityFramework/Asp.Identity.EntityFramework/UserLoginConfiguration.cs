using System;
using System.Data.Entity.ModelConfiguration;

namespace Asp.Identity.EntityFramework
{
    /// <summary>
    /// Mapping configuration for User Login
    /// </summary>
    public class UserLoginConfiguration : EntityTypeConfiguration<UserLogin>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public UserLoginConfiguration()
        {
            ToTable("Sec_UserLogins");

            HasKey(ul => new {ul.LoginProvider, ul.ProviderKey});
            HasRequired(ul => ul.User).WithMany(u => u.Logins).HasForeignKey(ul => ul.UserId).WillCascadeOnDelete(true);
        }

    }
}