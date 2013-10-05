using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace Asp.Identity
{
    /// <summary>
    /// 
    /// </summary>
    public class UserManagement : IUserManagement
    {
        #region Constructors--------------------------------------------------------
        
        /// <summary>
        /// Ctor
        /// </summary>
        public UserManagement()
        {
            LastSignInTimeUtc = DateTime.UtcNow;
        }

        #endregion

        /// <summary>
        /// The id of the User
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The User
        /// </summary>
        public virtual UserBase User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public bool DisableSignIn { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public DateTime LastSignInTimeUtc { get; set; }

    }
}