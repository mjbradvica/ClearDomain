// <copyright file="StringEntityTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.Common;
using ClearDomain.StringPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.StringPrimary
{
    /// <summary>
    /// String entity tests.
    /// </summary>
    [TestClass]
    public class StringEntityTests
    {
        /// <summary>
        /// Ensure the identifier is initialized by default.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_InstantiatesId()
        {
            var entity = new TestStringEntity();

            Assert.AreNotEqual(Guid.Empty.ToString(), entity.Id);
        }

        /// <summary>
        /// Ensures the string entity has the correct types.
        /// </summary>
        [TestMethod]
        public void Entity_HasTheCorrectTypes()
        {
            var entity = new TestStringEntity();

            Assert.IsInstanceOfType<Entity<string>>(entity);
            Assert.IsInstanceOfType<IEntity>(entity);
            Assert.IsInstanceOfType<IEntity<string>>(entity);
        }
    }
}
