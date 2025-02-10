// <copyright file="IAggregateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace ClearDomain.StringPrimary
{
    /// <summary>
    /// Interface constraint for a <see cref="string"/> AggregateRoot.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<string>, IEntity
    {
    }
}
