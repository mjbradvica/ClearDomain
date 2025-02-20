// <copyright file="IAggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace ClearDomain.Common
{
    /// <summary>
    /// Base interface for aggregate roots.
    /// </summary>
    /// <typeparam name="T">The type of the entity identifier.</typeparam>
    public interface IAggregateRoot<out T> : IEntity<T>
    {
        /// <summary>
        /// Gets all domain events for an aggregate root.
        /// </summary>
        public IEnumerable<IDomainEvent> DomainEvents { get; }
    }
}
