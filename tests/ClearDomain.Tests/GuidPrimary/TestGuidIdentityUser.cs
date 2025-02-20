// <copyright file="TestGuidIdentityUser.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.GuidPrimary;

namespace ClearDomain.Tests.GuidPrimary
{
    /// <summary>
    /// Test guid identity user.
    /// </summary>
    public class TestGuidIdentityUser : ClearDomainIdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestGuidIdentityUser"/> class.
        /// </summary>
        public TestGuidIdentityUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestGuidIdentityUser"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        public TestGuidIdentityUser(string username)
            : base(username)
        {
        }
    }
}
