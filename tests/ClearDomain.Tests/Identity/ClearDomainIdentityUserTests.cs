// <copyright file="ClearDomainIdentityUserTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediation.Abstractions;

namespace ClearDomain.Tests.Identity
{
    /// <summary>
    /// Tests for identity users.
    /// </summary>
    [TestClass]
    public class ClearDomainIdentityUserTests
    {
        /// <summary>
        /// Ensures all properties are initialized on creation.
        /// </summary>
        [TestMethod]
        public void UserNameConstructorInitializesProperties()
        {
            var user = new TestIdentityUser("user");

            Assert.IsNotNull(user.UserName);
        }

        /// <summary>
        /// Ensures entity equals is correct.
        /// </summary>
        [TestMethod]
        public void EqualsNullOtherReturnsCorrectResponse()
        {
            var user = new TestIdentityUser();

            var result = user.Equals(null);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Ensures entity equals is correct.
        /// </summary>
        [TestMethod]
        public void EqualsNullIdReturnsCorrectResponse()
        {
            var user = new TestIdentityUser();

            var other = new TestIdentityUser();

            var result = user.Equals(other);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Ensures entity equals is correct.
        /// </summary>
        [TestMethod]
        public void EqualsSuccessfulReturnsCorrectResponse()
        {
            var id = Guid.NewGuid().ToString();

            var user = new TestIdentityUser
            {
                Id = id,
            };

            var other = new TestIdentityUser
            {
                Id = id,
            };

            var result = user.Equals(other);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Ensures equals only runs for the correct type.
        /// </summary>
        [TestMethod]
        public void EqualsCorrectTypeReturnsCorrectResponse()
        {
            var id = Guid.NewGuid().ToString();

            var user = new TestIdentityUser
            {
                Id = id,
            };

            object other = new TestIdentityUser
            {
                Id = id,
            };

            var result = user.Equals(other);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Ensures equals only runs for the correct type.
        /// </summary>
        [TestMethod]
        public void EqualsIncorrectTypeReturnsCorrectResponse()
        {
            var user = new TestIdentityUser();

            object other = string.Empty;

            var result = user.Equals(other);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Ensures hash code is above floor.
        /// </summary>
        [TestMethod]
        public void GetHashCodeIsAboveMinimum()
        {
            var user = new TestIdentityUser();

            var hash = user.GetHashCode();

            Assert.IsGreaterThan(0, hash);
        }

        /// <summary>
        /// Ensures domain events are added.
        /// </summary>
        [TestMethod]
        public void AppendDomainEventIsAppended()
        {
            var user = new TestIdentityUser();

            user.AppendDomainEvent(new AggregateRootTests.TestDomainEvent());

            Assert.AreEqual(1, user.DomainEvents.Count());
        }

        /// <summary>
        /// Class has correct types.
        /// </summary>
        [TestMethod]
        public void ClassHasCorrectTypes()
        {
            var user = new TestIdentityUser();

            Assert.IsInstanceOfType<IdentityUser<string>>(user);
            Assert.IsInstanceOfType<IAggregateRoot<string, IOccurrence>>(user);
            Assert.IsInstanceOfType<IEquatable<IEntity<string>>>(user);
        }
    }
}
