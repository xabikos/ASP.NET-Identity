using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace Asp.Identity
{
    /// <summary>
    /// A security Token of the system
    /// </summary>
    public class Token : IToken
    {
        #region Constructors--------------------------------------------------------
        
        /// <summary>
        /// Ctor
        /// </summary>
        public Token()
        {
            Id = Guid.NewGuid().ToString();
            ValidUntilUtc = DateTime.MaxValue;
        }

        #endregion

        /// <summary>
        /// The Token's unique id
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// The Token's value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The Token's expiration date
        /// </summary>
        [Required]
        public DateTime ValidUntilUtc { get; set; }

    }
}