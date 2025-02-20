// <copyright file="ClearDomainIdentityUser.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.Common;
using ClearDomain.StringPrimary;

namespace ClearDomain.Identity.StringPrimary
{
    /// <summary>
    /// Base class for a <see cref="string"/> identity user with ClearDomain functionality.
    /// </summary>
    public abstract class ClearDomainIdentityUser : ClearDomainIdentityUser<string>, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClearDomainIdentityUser"/> class.
        /// </summary>
        protected ClearDomainIdentityUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearDomainIdentityUser"/> class.
        /// </summary>
        /// <param name="userName">The username for the identity user.</param>
        protected ClearDomainIdentityUser(string userName)
            : base(userName)
        {
        }
    }
}
