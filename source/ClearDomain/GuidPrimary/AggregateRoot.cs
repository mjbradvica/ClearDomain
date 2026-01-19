// <copyright file="AggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using NMediation.Abstractions;

namespace ClearDomain.GuidPrimary
{
    /// <summary>
    /// Base class for all <see cref="Guid"/> aggregate roots.
    /// </summary>
    public abstract class AggregateRoot : AggregateRoot<Guid, IOccurrence>, IAggregateRoot
    {
#if NET8_0
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        protected AggregateRoot()
            : this(Guid.NewGuid())
        {
        }
#else
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        protected AggregateRoot()
            : this(Guid.CreateVersion7())
        {
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        /// <param name="id">The identifier for the aggregate root.</param>
        protected AggregateRoot(Guid id)
            : base(id)
        {
        }
    }
}
