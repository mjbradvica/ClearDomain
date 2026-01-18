// <copyright file="IAggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using NMediation.Abstractions;

namespace ClearDomain.GuidPrimary
{
    /// <summary>
    /// Interface constraint for a <see cref="Guid"/> AggregateRoot.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<Guid, IOccurrence>, IEntity
    {
    }
}
