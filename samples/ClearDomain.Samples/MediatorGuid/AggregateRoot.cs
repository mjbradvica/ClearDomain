// <copyright file="AggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using MediatR;

namespace ClearDomain.Samples.MediatorGuid
{
    /// <inheritdoc cref="IAggregateRoot" />
    public abstract class AggregateRoot : AggregateRoot<Guid, INotification>, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        protected AggregateRoot()
            : base(Guid.NewGuid())
        {
        }

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
