// <copyright file="Entity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace ClearDomain.GuidPrimary
{
    /// <summary>
    /// Base class for all <see cref="Guid"/> entities.
    /// </summary>
    public abstract class Entity : Entity<Guid>, IEntity
    {
#if NET8_0
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        protected Entity()
            : this(Guid.NewGuid())
        {
        }
#else
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        protected Entity()
            : this(Guid.CreateVersion7())
        {
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        protected Entity(Guid id)
            : base(id)
        {
        }
    }
}
