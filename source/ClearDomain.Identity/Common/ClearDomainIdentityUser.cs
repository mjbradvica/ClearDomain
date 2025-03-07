﻿// <copyright file="ClearDomainIdentityUser.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using Microsoft.AspNetCore.Identity;

namespace ClearDomain.Identity.Common
{
    /// <summary>
    /// Base class for an identity user with ClearDomain functionality.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <typeparam name="TDomainEvent">The type of the domain event.</typeparam>
    public abstract class ClearDomainIdentityUser<TId, TDomainEvent> : IdentityUser<TId>, IAggregateRoot<TId, TDomainEvent>, IEquatable<IEntity<TId>>
        where TId : IEquatable<TId>
        where TDomainEvent : class
    {
        private readonly List<TDomainEvent> _domainEvents;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearDomainIdentityUser{TId, TDomainEvent}"/> class.
        /// </summary>
        protected ClearDomainIdentityUser()
        {
            _domainEvents = new List<TDomainEvent>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearDomainIdentityUser{TId, TDomainEvent}"/> class.
        /// </summary>
        /// <param name="userName">The username for the identity user.</param>
        protected ClearDomainIdentityUser(string userName)
            : base(userName)
        {
            _domainEvents = new List<TDomainEvent>();
        }

        /// <inheritdoc />
        public IEnumerable<TDomainEvent> DomainEvents => _domainEvents.AsEnumerable();

        /// <summary>
        /// Determines equality for another entity.
        /// </summary>
        /// <param name="other">The other entity to compare.</param>
        /// <returns>A <see cref="bool"/> indicating if the objects are equal.</returns>
        public bool Equals(IEntity<TId>? other)
        {
            if (other == null)
            {
                return false;
            }

            if (Id == null)
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        /// <summary>
        /// Determines equality for another object.
        /// </summary>
        /// <param name="obj">The other object to compare.</param>
        /// <returns>A <see cref="bool"/> indicating if the objects are equal.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is IEntity<TId> user)
            {
                return Equals(user);
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for the entity. This is required by the <see cref="IEquatable{T}"/> interface.
        /// </summary>
        /// <returns>A <see cref="int"/> hash code for the entity.</returns>
        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

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
