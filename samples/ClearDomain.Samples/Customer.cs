// <copyright file="Customer.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.GuidPrimary;

namespace ClearDomain.Samples
{
    /// <summary>
    /// Sample identity user.
    /// </summary>
    public sealed class Customer : ClearDomainIdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            Id = Guid.NewGuid();
            SecurityStamp = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        public Customer(Guid id)
        {
            Id = id;
            SecurityStamp = Guid.NewGuid().ToString();

            if (Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
        }
    }
}
