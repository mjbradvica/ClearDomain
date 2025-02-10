// <copyright file="IEntity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace ClearDomain.Common
{
    /// <summary>
    /// Base interface for all entities.
    /// </summary>
    /// <typeparam name="T">The type of the identifier.</typeparam>
    public interface IEntity<out T>
    {
        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        public T Id { get; }
    }
}
