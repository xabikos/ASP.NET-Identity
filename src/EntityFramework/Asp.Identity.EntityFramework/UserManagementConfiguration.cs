using System;
using System.Data.Entity.ModelConfiguration;

namespace Asp.Identity.EntityFramework
{
    /// <summary>
    /// Mapping configuration for User Management
    /// </summary>
    public class UserManagementConfiguration : EntityTypeConfiguration<UserManagement>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public UserManagementConfiguration()
        {
            ToTable("Sec_UserManagement");

            HasKey(um => um.UserId);
            HasRequired(um => um.User).WithOptional(u => u.Management).WillCascadeOnDelete(true);
        }

    }
}