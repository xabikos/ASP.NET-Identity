using System;
using System.Data.Entity.ModelConfiguration;

namespace Asp.Identity.EntityFramework
{
    /// <summary>
    /// Mapping configuration for User Role
    /// </summary>
    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public UserRoleConfiguration()
        {
            ToTable("Sec_UserRole");

            HasKey(ur => new {ur.RoleId, ur.UserId});
            HasRequired(ur => ur.User).WithMany(u => u.Roles).HasForeignKey(ur => ur.UserId).WillCascadeOnDelete(true);
            HasRequired(ur => ur.Role).WithMany().HasForeignKey(ur=>ur.RoleId).WillCascadeOnDelete(false);
        }
    }
}