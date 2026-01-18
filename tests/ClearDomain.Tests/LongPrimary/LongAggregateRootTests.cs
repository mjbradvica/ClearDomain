// <copyright file="LongAggregateRootTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.LongPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediation.Abstractions;

namespace ClearDomain.Tests.LongPrimary
{
    /// <summary>
    /// Tests for a <see cref="AggregateRoot"/>.
    /// </summary>
    [TestClass]
    public class LongAggregateRootTests
    {
        /// <summary>
        /// Ensure that events are instantiated on initialization.
        /// </summary>
        [TestMethod]
        public void DefaultConstructorInstantiatesObject()
        {
            var root = new TestAggregateRoot();

            Assert.IsNotNull(root);
        }

        /// <summary>
        /// Ensure that events are instantiated on initialization.
        /// </summary>
        [TestMethod]
        public void NonDefaultConstructorInstantiatesObject()
        {
            var root = new TestAggregateRoot(1);

            Assert.IsNotNull(root);
        }

        /// <summary>
        /// Ensures the class has the correct types.
        /// </summary>
        [TestMethod]
        public void AggregateRootHasCorrectTypes()
        {
            var root = new TestAggregateRoot(1);

            Assert.IsInstanceOfType<AggregateRoot<long, IOccurrence>>(root);
            Assert.IsInstanceOfType<IAggregateRoot>(root);
        }

        /// <summary>
        /// Test aggregate root.
        /// </summary>
        internal sealed class TestAggregateRoot : AggregateRoot
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestAggregateRoot"/> class.
            /// </summary>
            public TestAggregateRoot()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="TestAggregateRoot"/> class.
            /// </summary>
            /// <param name="id">The identifier for the aggregate root.</param>
            public TestAggregateRoot(long id)
                : base(id)
            {
            }
        }
    }
}
