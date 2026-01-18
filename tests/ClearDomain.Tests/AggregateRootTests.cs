// <copyright file="AggregateRootTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.GuidPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediation.Abstractions;

namespace ClearDomain.Tests
{
    /// <summary>
    /// Tests for aggregate roots.
    /// </summary>
    [TestClass]
    public class AggregateRootTests
    {
        /// <summary>
        /// Ensure that events are instantiated on initialization.
        /// </summary>
        [TestMethod]
        public void DefaultConstructorInstantiatesEvents()
        {
            var root = new TestAggregateRoot();

            Assert.IsNotNull(root.DomainEvents);
        }

        /// <summary>
        /// Ensure that events are instantiated on initialization.
        /// </summary>
        [TestMethod]
        public void NonDefaultConstructorInstantiatesEvents()
        {
            var root = new TestAggregateRoot(Guid.NewGuid());

            Assert.IsNotNull(root.DomainEvents);
        }

        /// <summary>
        /// Ensures domain events are appended to the list.
        /// </summary>
        [TestMethod]
        public void AddNotificationAppendsToEvents()
        {
            var root = new TestAggregateRoot();

            root.AppendDomainEvent(new TestDomainEvent());

            Assert.AreEqual(1, root.DomainEvents.Count());
        }

        /// <summary>
        /// Ensures an aggregate root has the correct types.
        /// </summary>
        [TestMethod]
        public void AggregateRootHasTheCorrectTypes()
        {
            var root = new TestAggregateRoot();

            Assert.IsInstanceOfType<Entity<Guid>>(root);
            Assert.IsInstanceOfType<IAggregateRoot<Guid, IOccurrence>>(root);

            IEntity<Guid> secondRoot = new TestAggregateRoot();

            Assert.IsInstanceOfType<IEntity<Guid>>(secondRoot);
        }

        /// <summary>
        /// Test domain event.
        /// </summary>
        public class TestDomainEvent : IOccurrence
        {
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
            public TestAggregateRoot(Guid id)
                : base(id)
            {
            }
        }
    }
}
