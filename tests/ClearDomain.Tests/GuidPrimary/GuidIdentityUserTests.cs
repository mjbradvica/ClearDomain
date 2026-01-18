// <copyright file="GuidIdentityUserTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using ClearDomain.Identity.Common;
using ClearDomain.Identity.GuidPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediation.Abstractions;

namespace ClearDomain.Tests.GuidPrimary
{
    /// <summary>
    /// Tests for the <see cref="ClearDomainIdentityUser"/> class.
    /// </summary>
    [TestClass]
    public class GuidIdentityUserTests
    {
        /// <summary>
        /// Class has default constructor.
        /// </summary>
        [TestMethod]
        public void ClassHasDefaultConstructor()
        {
            var user = new TestGuidIdentityUser();

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has default constructor.
        /// </summary>
        [TestMethod]
        public void ClassHasUsernameConstructor()
        {
            var user = new TestGuidIdentityUser("username");

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has correct types.
        /// </summary>
        [TestMethod]
        public void ClassHasCorrectTypes()
        {
            var user = new TestGuidIdentityUser();

            Assert.IsInstanceOfType<ClearDomainIdentityUser<Guid, IOccurrence>>(user);
            Assert.IsInstanceOfType<IAggregateRoot>(user);
        }
    }
}
