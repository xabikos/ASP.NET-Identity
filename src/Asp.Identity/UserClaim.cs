using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace Asp.Identity
{
    /// <summary>
    /// A Claim that belongs to a User
    /// </summary>
    public class UserClaim : IUserClaim
    {
        /// <summary>
        /// The UserClaim's unique id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The id of the User the Claim belongs to
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// The User the Claim belongs to
        /// </summary>
        public virtual UserBase User { get; set; }

        /// <summary>
        /// The Claim's type
        /// </summary>
        public string ClaimType { get; set; }

        /// <summary>
        /// The Claim's value
        /// </summary>
        public string ClaimValue { get; set; }

    }
}