// <copyright file="IntEntityTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.IntPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.IntPrimary
{
    /// <summary>
    /// Int entity tests.
    /// </summary>
    [TestClass]
    public class IntEntityTests
    {
        /// <summary>
        /// Ensures the int entity has the correct types.
        /// </summary>
        [TestMethod]
        public void EntityHasTheCorrectTypes()
        {
            var entity = new TestIntEntity(1);

            Assert.IsInstanceOfType<Entity<int>>(entity);
            Assert.IsInstanceOfType<IEntity>(entity);
            Assert.IsInstanceOfType<IEntity<int>>(entity);
        }
    }
}
