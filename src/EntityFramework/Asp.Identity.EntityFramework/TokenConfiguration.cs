using System;
using System.Data.Entity.ModelConfiguration;

namespace Asp.Identity.EntityFramework
{
    /// <summary>
    /// Mapping configuration for Token
    /// </summary>
    public class TokenConfiguration : EntityTypeConfiguration<Token>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public TokenConfiguration()
        {
            ToTable("Sec_UserTokens");

            HasKey(t => t.Id);
        }

    }
}