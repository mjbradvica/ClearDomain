﻿// <copyright file="EntityTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.Tests.GuidPrimary;
using ClearDomain.Tests.IntPrimary;
using ClearDomain.Tests.LongPrimary;
using ClearDomain.Tests.StringPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests
{
    /// <summary>
    /// Test for entity objects.
    /// </summary>
    [TestClass]
    public class EntityTests
    {
        /// <summary>
        /// Ensures the constructor instantiates the identifier.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_InstantiatesId()
        {
            var entity = new TestGuidEntity(Guid.NewGuid());

            Assert.AreNotEqual(Guid.Empty, entity.Id);
        }

        /// <summary>
        /// Ensures the entity throws an exception on an empty guid.
        /// </summary>
        [TestMethod]
        public void GuidConstructor_EmptyId_ThrowsException()
        {
            Assert.ThrowsExactly<NullReferenceException>(() => _ = new TestGuidEntity(Guid.Empty));
        }

        /// <summary>
        /// Ensures the entity throws an exception on a zeroed int.
        /// </summary>
        [TestMethod]
        public void IntConstructor_EmptyId_ThrowsException()
        {
            Assert.ThrowsExactly<NullReferenceException>(() => _ = new TestIntEntity(0));
        }

        /// <summary>
        /// Ensures the entity throws an exception on a zeroed long.
        /// </summary>
        [TestMethod]
        public void LongConstructor_EmptyId_ThrowsException()
        {
            Assert.ThrowsExactly<NullReferenceException>(() => _ = new TestLongEntity(0));
        }

        /// <summary>
        /// Ensures the entity throws an exception on a zeroed long.
        /// </summary>
        [TestMethod]
        public void StringConstructor_EmptyId_ThrowsException()
        {
            Assert.ThrowsExactly<NullReferenceException>(() => _ = new TestStringEntity(string.Empty));
        }

        /// <summary>
        /// Ensures a null equality comparison returns correct result.
        /// </summary>
        [TestMethod]
        public void Equals_NullEntity_ReturnsFalse()
        {
            var entity = new TestGuidEntity(Guid.NewGuid());

            Assert.IsFalse(entity.Equals(null));
        }

        /// <summary>
        /// Ensures an entity comparison returns the correct result.
        /// </summary>
        [TestMethod]
        public void Equals_NonNullEntity_ReturnsTrue()
        {
            var id = Guid.NewGuid();

            var first = new TestGuidEntity(id);
            var second = new TestGuidEntity(id);

            Assert.IsTrue(first.Equals(second));
        }

        /// <summary>
        /// Ensures an entity comparison returns the correct result.
        /// </summary>
        [TestMethod]
        public void Equals_EntityObject_ReturnsTrue()
        {
            var id = Guid.NewGuid();

            var first = new TestGuidEntity(id);
            object second = new TestGuidEntity(id);

            Assert.IsTrue(first.Equals(second));
        }

        /// <summary>
        /// Ensures a null entity id returns the correct result.
        /// </summary>
        [TestMethod]
        public void Equal_EntityObject_NullId_ReturnsFalse()
        {
            var first = new TestStringEntity
            {
                Id = null!,
            };
            var second = new TestStringEntity();

            Assert.IsFalse(first.Equals(second));
        }

        /// <summary>
        /// Ensures an entity comparison returns the correct result.
        /// </summary>
        [TestMethod]
        public void Equals_NonEntityObject_ReturnsFalse()
        {
            var first = new TestGuidEntity(Guid.NewGuid());
            object second = "notAnEntity";

            Assert.IsFalse(first.Equals(second));
        }

        /// <summary>
        /// Ensures the hash code is above the floor value.
        /// </summary>
        [TestMethod]
        public void GetHashCode_ReturnsMinimumValue()
        {
            var entity = new TestGuidEntity(Guid.NewGuid());

            Assert.IsTrue(entity.GetHashCode() > 0);
        }

        /// <summary>
        /// Entities derive from correct types.
        /// </summary>
        [TestMethod]
        public void Entity_IsTheCorrectType()
        {
            var entity = new TestGuidEntity(Guid.NewGuid());

            Assert.IsInstanceOfType<IEntity<Guid>>(entity);
            Assert.IsInstanceOfType<IEquatable<IEntity<Guid>>>(entity);
        }
    }
}
