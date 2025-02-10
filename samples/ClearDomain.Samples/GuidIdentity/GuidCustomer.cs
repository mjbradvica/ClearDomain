// <copyright file="GuidCustomer.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.GuidPrimary;

namespace ClearDomain.Samples.GuidIdentity
{
    /// <summary>
    /// Sample <see cref="Guid"/> identity user.
    /// </summary>
    public sealed class GuidCustomer : ClearDomainIdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidCustomer"/> class.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="userName">The customer username.</param>
        public GuidCustomer(Guid id, string userName)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
            UserName = userName;
            SecurityStamp = Guid.NewGuid().ToString();

            AppendDomainEvent(new CustomerCreated());
        }
    }
}
