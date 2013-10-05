using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace Asp.Identity
{
    /// <summary>
    /// Base class for the Users of the application
    /// </summary>
    public class UserBase : IUser
    {
        #region Constructors--------------------------------------------------------
        
        /// <summary>
        /// Ctor
        /// </summary>
        public UserBase()
        {
            Id = Guid.NewGuid().ToString();
            Logins = new Collection<UserLogin>();
            Claims = new Collection<UserClaim>();
        }

        #endregion

        /// <summary>
        /// The User's unique id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The user name
        /// </summary>
        [Required]
        public string UserName { get; set; }
        
        /// <summary>
        /// The User's email address
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// The User's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The User's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The user's address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Additional info for the User
        /// </summary>
        public virtual UserManagement Management { get; set; }

        /// <summary>
        /// The User's Login
        /// </summary>
        public virtual ICollection<UserLogin> Logins { get; set; }

        /// <summary>
        /// The User's Claims
        /// </summary>
        public virtual ICollection<UserClaim> Claims { get; set; } 
        
    }
}