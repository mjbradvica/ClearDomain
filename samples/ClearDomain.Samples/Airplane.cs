// <copyright file="Airplane.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;

namespace ClearDomain.Samples
{
    /// <summary>
    /// Sample long entity.
    /// </summary>
    public class Airplane : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Airplane"/> class.
        /// </summary>
        /// <param name="id">The airplane identifier.</param>
        public Airplane(long id)
            : base(id)
        {
        }
    }
}
