﻿// <copyright file="AggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using SimpleDomain.Common;

namespace SimpleDomain.IntPrimary
{
    /// <summary>
    /// Base class for all <see cref="int"/> aggregate roots.
    /// </summary>
    public abstract class AggregateRoot : AggregateRoot<int>, IAggregateRoot
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
        /// <param name="id">The identifier for the aggregate root.</param>
        protected AggregateRoot(int id)
            : base(id)
        {
        }
    }
}
