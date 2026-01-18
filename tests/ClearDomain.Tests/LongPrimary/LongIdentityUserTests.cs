// <copyright file="LongIdentityUserTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.Common;
using ClearDomain.Identity.LongPrimary;
using ClearDomain.LongPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediation.Abstractions;

namespace ClearDomain.Tests.LongPrimary
{
    /// <summary>
    /// Tests for the <see cref="ClearDomainIdentityUser"/> class.
    /// </summary>
    [TestClass]
    public class LongIdentityUserTests
    {
        /// <summary>
        /// Class has default constructor.
        /// </summary>
        [TestMethod]
        public void ClassHasDefaultConstructor()
        {
            var user = new TestLongIdentityUser();

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has username constructor.
        /// </summary>
        [TestMethod]
        public void ClassHasUsernameConstructor()
        {
            var user = new TestLongIdentityUser("user");

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has correct types.
        /// </summary>
        [TestMethod]
        public void ClassHasCorrectTypes()
        {
            var user = new TestLongIdentityUser();

            Assert.IsInstanceOfType<ClearDomainIdentityUser<long, IOccurrence>>(user);
            Assert.IsInstanceOfType<IAggregateRoot>(user);
        }
    }
}
