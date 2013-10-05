using System;
using System.Data.Entity.ModelConfiguration;

namespace Asp.Identity.EntityFramework
{
    /// <summary>
    /// Mapping configuration for User
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<UserBase>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public UserConfiguration()
        {
            ToTable("Sec_Users");

            HasKey(u => u.Id);
        }

    }
}