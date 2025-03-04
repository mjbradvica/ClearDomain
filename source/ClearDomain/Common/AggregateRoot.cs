// <copyright file="AggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace ClearDomain.Common
{
    /// <summary>
    /// A base class for aggregate roots.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <typeparam name="TDomainEvent">The type of the domain event.</typeparam>
    public abstract class AggregateRoot<TId, TDomainEvent> : Entity<TId>, IAggregateRoot<TId, TDomainEvent>
        where TId : IEquatable<TId>
        where TDomainEvent : class
    {
        private readonly List<TDomainEvent> _domainEvents;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot{TId, TDomainEvent}"/> class.
        /// </summary>
        protected AggregateRoot()
        {
            _domainEvents = new List<TDomainEvent>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot{TId, TDomainEvent}"/> class.
        /// </summary>
        /// <param name="id">The identifier for the aggregate root.</param>
        protected AggregateRoot(TId id)
            : base(id)
        {
            _domainEvents = new List<TDomainEvent>();
        }

        /// <inheritdoc />
        public IEnumerable<TDomainEvent> DomainEvents => _domainEvents.AsEnumerable();

        /// <summary>
        /// Appends a domain event to the current list.
        /// </summary>
        /// <param name="domainEvent">A <typeparamref name="TDomainEvent"/> to append.</param>
        public void AppendDomainEvent(TDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
