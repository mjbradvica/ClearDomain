﻿// <copyright file="Entity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace ClearDomain.Common
{
    /// <summary>
    /// A base class for entities.
    /// </summary>
    /// <typeparam name="T">The type of the entity identifier.</typeparam>
    public abstract class Entity<T> : IEntity<T>, IEquatable<IEntity<T>>
        where T : IEquatable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{T}"/> class.
        /// </summary>
        protected Entity()
        {
            /*
             * We can't use the struct generic constraint because we support strings.
             * The identifier value will never be null because the string version always initializes itself.
             * The compiler has no knowledge of this, thus the bang operator is required.
             */
            Id = default!;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{T}"/> class.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        protected Entity(T id)
            : this()
        {
            Id = id;

            if (Id is Guid guidId)
            {
                if (guidId == Guid.Empty)
                {
                    throw new NullReferenceException(nameof(Id));
                }
            }

            if (Id is int intId)
            {
                if (intId <= 0)
                {
                    throw new NullReferenceException(nameof(Id));
                }
            }

            if (Id is long longId)
            {
                if (longId <= 0)
                {
                    throw new NullReferenceException(nameof(Id));
                }
            }

            if (Id is string stringId)
            {
                if (string.IsNullOrWhiteSpace(stringId))
                {
                    throw new NullReferenceException(nameof(Id));
                }
            }
        }

        /// <inheritdoc />
        public T Id { get; init; }

        /// <summary>
        /// Determines equality for another entity.
        /// </summary>
        /// <param name="other">The other entity to compare.</param>
        /// <returns>A <see cref="bool"/> indicating if the objects are equal.</returns>
        public bool Equals(IEntity<T>? other)
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
            if (obj is IEntity<T> entity)
            {
                return Equals(entity);
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
    }
}
