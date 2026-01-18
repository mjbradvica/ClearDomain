// <copyright file="IntIdentityUserTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.Common;
using ClearDomain.Identity.IntPrimary;
using ClearDomain.IntPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediation.Abstractions;

namespace ClearDomain.Tests.IntPrimary
{
    /// <summary>
    /// Tests for the <see cref="ClearDomainIdentityUser"/> class.
    /// </summary>
    [TestClass]
    public class IntIdentityUserTests
    {
        /// <summary>
        /// Class has default constructor.
        /// </summary>
        [TestMethod]
        public void ClassHasDefaultConstructor()
        {
            var user = new TestIntIdentityUser();

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has username constructor.
        /// </summary>
        [TestMethod]
        public void ClassHasUsernameConstructor()
        {
            var user = new TestIntIdentityUser("user");

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has correct types.
        /// </summary>
        [TestMethod]
        public void ClassHasCorrectTypes()
        {
            var user = new TestIntIdentityUser();

            Assert.IsInstanceOfType<ClearDomainIdentityUser<int, IOccurrence>>(user);
            Assert.IsInstanceOfType<IAggregateRoot>(user);
        }
    }
}
