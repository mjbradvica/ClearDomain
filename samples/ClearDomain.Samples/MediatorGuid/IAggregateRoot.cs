// <copyright file="IAggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using NMediation.Abstractions;

namespace ClearDomain.Samples.MediatorGuid
{
    /// <inheritdoc />
    public interface IAggregateRoot : IAggregateRoot<Guid, IOccurrence>
    {
    }
}
