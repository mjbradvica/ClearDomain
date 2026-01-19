// <copyright file="IAggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using NMediation.Abstractions;

namespace ClearDomain.LongPrimary
{
    /// <summary>
    /// Interface constraint for a <see cref="long"/> AggregateRoot.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<long, IOccurrence>, IEntity
    {
    }
}
