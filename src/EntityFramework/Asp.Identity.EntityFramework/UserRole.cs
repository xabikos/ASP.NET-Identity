using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Asp.Identity.EntityFramework
{
    /// <summary>
    /// Connect a User to a Role
    /// </summary>
    public class UserRole : IUserRole
    {
        /// <summary>
        /// The unique id of the User
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// The User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// The unique id of the Role
        /// </summary>
        [Required]
        public string RoleId { get; set; }

        /// <summary>
        /// The Role
        /// </summary>
        public virtual Role Role { get; set; }

    }
}