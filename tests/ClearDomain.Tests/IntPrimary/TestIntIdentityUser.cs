// <copyright file="TestIntIdentityUser.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.IntPrimary;

namespace ClearDomain.Tests.IntPrimary
{
    /// <summary>
    /// Test int identity user.
    /// </summary>
    public class TestIntIdentityUser : ClearDomainIdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestIntIdentityUser"/> class.
        /// </summary>
        public TestIntIdentityUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestIntIdentityUser"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        public TestIntIdentityUser(string username)
        : base(username)
        {
        }
    }
}
