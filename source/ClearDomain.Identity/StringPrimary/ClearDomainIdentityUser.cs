﻿// <copyright file="ClearDomainIdentityUser.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.Common;

namespace ClearDomain.Identity.StringPrimary
{
    /// <inheritdoc />
    public abstract class ClearDomainIdentityUser : ClearDomainIdentityUser<string>
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