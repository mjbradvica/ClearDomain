// <copyright file="AggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using NMediation.Abstractions;

namespace ClearDomain.StringPrimary
{
    /// <summary>
    /// Base class for all <see cref="string"/> aggregate roots.
    /// </summary>
    public abstract class AggregateRoot : AggregateRoot<string, IOccurrence>, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        protected AggregateRoot()
            : base(Guid.CreateVersion7().ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        /// <param name="id">The identifier for the aggregate root.</param>
        protected AggregateRoot(string id)
            : base(id)
        {
        }
    }
}
