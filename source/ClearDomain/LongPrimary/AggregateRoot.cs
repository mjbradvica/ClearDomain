// <copyright file="AggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using NMediation.Abstractions;

namespace ClearDomain.LongPrimary
{
    /// <summary>
    /// Base class for all <see cref="long"/> aggregate roots.
    /// </summary>
    public abstract class AggregateRoot : AggregateRoot<long, IOccurrence>, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        protected AggregateRoot()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        /// <param name="id">The identifier for an aggregate root.</param>
        protected AggregateRoot(long id)
            : base(id)
        {
        }
    }
}
