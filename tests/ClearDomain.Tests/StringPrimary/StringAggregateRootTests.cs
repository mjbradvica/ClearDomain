// <copyright file="StringAggregateRootTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.StringPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediation.Abstractions;

namespace ClearDomain.Tests.StringPrimary
{
    /// <summary>
    /// Tests for a <see cref="AggregateRoot"/>.
    /// </summary>
    [TestClass]
    public class StringAggregateRootTests
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
            var root = new TestAggregateRoot("4");

            Assert.IsNotNull(root);
        }

        /// <summary>
        /// Ensures the class has the correct types.
        /// </summary>
        [TestMethod]
        public void AggregateRootHasCorrectTypes()
        {
            var root = new TestAggregateRoot("2");

            Assert.IsInstanceOfType<AggregateRoot<string, IOccurrence>>(root);
            Assert.IsInstanceOfType<IAggregateRoot>(root);
        }

        /// <summary>
        /// Default constructor instantiates identifier.
        /// </summary>
        [TestMethod]
        public void DefaultConstructorInstantiatesIdentifier()
        {
            var aggregateRoot = new TestAggregateRoot();

            Assert.AreNotEqual(string.Empty, aggregateRoot.Id);
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
            public TestAggregateRoot(string id)
                : base(id)
            {
            }
        }
    }
}
