using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace Asp.Identity
{
    /// <summary>
    /// Login info for a specific User
    /// </summary>
    public class UserLogin : IUserLogin
    {
        /// <summary>
        /// The Login's provider
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// The provider's key
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        /// The id of the User the Login is for
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// The User the Login is for
        /// </summary>
        public virtual UserBase User { get; set; }
        
    }
}