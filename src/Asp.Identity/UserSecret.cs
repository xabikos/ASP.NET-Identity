using System;
using Microsoft.AspNet.Identity;

namespace Asp.Identity
{
    /// <summary>
    /// A Secret that belongs to a User
    /// </summary>
    public class UserSecret : IUserSecret
    {
        /// <summary>
        /// The User's username
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// The User's secret
        /// </summary>
        public string Secret { get; set; }

    }
}