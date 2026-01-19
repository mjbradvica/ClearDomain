// <copyright file="LongEntityTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.LongPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.LongPrimary
{
    /// <summary>
    /// Long entity tests.
    /// </summary>
    [TestClass]
    public class LongEntityTests
    {
        /// <summary>
        /// Ensures the long entity has the correct types.
        /// </summary>
        [TestMethod]
        public void EntityHasTheCorrectTypes()
        {
            var entity = new TestLongEntity();

            Assert.IsInstanceOfType<Entity<long>>(entity);
            Assert.IsInstanceOfType<IEntity>(entity);
            Assert.IsInstanceOfType<IEntity<long>>(entity);
        }
    }
}
