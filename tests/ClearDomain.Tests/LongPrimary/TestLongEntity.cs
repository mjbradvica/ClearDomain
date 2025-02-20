﻿// <copyright file="TestLongEntity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;

namespace ClearDomain.Tests.LongPrimary
{
    /// <summary>
    /// Test long entity.
    /// </summary>
    public class TestLongEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestLongEntity"/> class.
        /// </summary>
        public TestLongEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestLongEntity"/> class.
        /// </summary>
        /// <param name="id">The identifier for the test entity.</param>
        public TestLongEntity(long id)
            : base(id)
        {
        }
    }
}
