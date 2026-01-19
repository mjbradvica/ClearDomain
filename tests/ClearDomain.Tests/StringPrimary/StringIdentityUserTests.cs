// <copyright file="StringIdentityUserTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.Common;
using ClearDomain.Identity.StringPrimary;
using ClearDomain.StringPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediation.Abstractions;

namespace ClearDomain.Tests.StringPrimary
{
    /// <summary>
    /// Tests for the <see cref="ClearDomainIdentityUser"/> class.
    /// </summary>
    [TestClass]
    public class StringIdentityUserTests
    {
        /// <summary>
        /// Class has default constructor.
        /// </summary>
        [TestMethod]
        public void ClassHasDefaultConstructor()
        {
            var user = new TestStringIdentityUser();

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has username constructor.
        /// </summary>
        [TestMethod]
        public void ClassHasUsernameConstructor()
        {
            var user = new TestStringIdentityUser("user");

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has correct types.
        /// </summary>
        [TestMethod]
        public void ClassHasCorrectTypes()
        {
            var user = new TestStringIdentityUser();

            Assert.IsInstanceOfType<ClearDomainIdentityUser<string, IOccurrence>>(user);
            Assert.IsInstanceOfType<IAggregateRoot>(user);
        }
    }
}
