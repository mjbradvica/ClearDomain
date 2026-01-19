// <copyright file="IAggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using NMediation.Abstractions;

namespace ClearDomain.IntPrimary
{
    /// <summary>
    /// Interface constraint for a <see cref="int"/> AggregateRoot.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<int, IOccurrence>, IEntity
    {
    }
}
