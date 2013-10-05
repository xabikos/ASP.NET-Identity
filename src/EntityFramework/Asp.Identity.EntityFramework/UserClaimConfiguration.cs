using System;
using System.Data.Entity.ModelConfiguration;

namespace Asp.Identity.EntityFramework
{
    /// <summary>
    /// Mapping configuration for User Claim
    /// </summary>
    public class UserClaimConfiguration : EntityTypeConfiguration<UserClaim>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public UserClaimConfiguration()
        {
            ToTable("Sec_UserClaims");

            HasKey(uc => uc.Id);
            HasRequired(uc => uc.User).WithMany(u => u.Claims).HasForeignKey(uc => uc.UserId).WillCascadeOnDelete(true);
        }

    }
}