// <copyright file="IAggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace ClearDomain.Common
{
    /// <summary>
    /// Base interface for aggregate roots.
    /// </summary>
    /// <typeparam name="TId">The type of the entity identifier.</typeparam>
    /// <typeparam name="TEvent">The type of the domain event.</typeparam>
    public interface IAggregateRoot<out TId, out TEvent> : IEntity<TId>
        where TEvent : class
    {
        /// <summary>
        /// Gets all domain events for an aggregate root.
        /// </summary>
        public IEnumerable<TEvent> DomainEvents { get; }
    }
}
