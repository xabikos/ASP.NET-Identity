using System;
using System.Data.Entity.ModelConfiguration;

namespace Asp.Identity.EntityFramework
{
    /// <summary>
    /// Mapping configuration for User Secret
    /// </summary>
    public class UserSecretConfiguration : EntityTypeConfiguration<UserSecret>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public UserSecretConfiguration()
        {
            ToTable("Sec_UserSecrets");

            HasKey(us => us.UserName);
        }

    }
}