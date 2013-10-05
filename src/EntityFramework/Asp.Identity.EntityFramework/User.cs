using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Asp.Identity.EntityFramework
{
    /// <summary>
    /// Class for User that includes the Roles 
    /// </summary>
    public class User : UserBase
    {
        #region Constructors--------------------------------------------------------

        /// <summary>
        /// Ctor
        /// </summary>
        public User()
        {
            Roles = new Collection<UserRole>();    
        }
        
        #endregion

        /// <summary>
        /// The Roles that a User posses
        /// </summary>
        public virtual ICollection<UserRole> Roles { get; set; }

    }
}