// <copyright file="GuidIdentityUserTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.GuidPrimary;
using ClearDomain.Identity.Common;
using ClearDomain.Identity.GuidPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void Class_HasDefaultConstructor()
        {
            var user = new TestGuidIdentityUser();

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has default constructor.
        /// </summary>
        [TestMethod]
        public void Class_HasUsernameConstructor()
        {
            var user = new TestGuidIdentityUser("username");

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has correct types.
        /// </summary>
        [TestMethod]
        public void Class_HasCorrectTypes()
        {
            var user = new TestGuidIdentityUser();

            Assert.IsInstanceOfType<ClearDomainIdentityUser<Guid, IDomainEvent>>(user);
            Assert.IsInstanceOfType<IAggregateRoot>(user);
        }
    }
}
