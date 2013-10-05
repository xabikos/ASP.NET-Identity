using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace Asp.Identity
{
    /// <summary>
    /// A Role in the system
    /// </summary>
    public class Role : IRole
    {
        #region Constructors--------------------------------------------------------
        
        /// <summary>
        /// Ctor
        /// </summary>
        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }

        #endregion

        /// <summary>
        /// The Role's unique id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The Role's name
        /// </summary>
        [Required]
        public string Name { get; set; }

    }
}