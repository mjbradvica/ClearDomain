﻿// <copyright file="GuidCustomerContext.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClearDomain.Samples.GuidIdentity
{
    /// <summary>
    /// Sample guid customer context.
    /// </summary>
    internal sealed class GuidCustomerContext : IdentityDbContext<GuidCustomer, IdentityRole<Guid>, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidCustomerContext"/> class.
        /// </summary>
        /// <param name="options">The configuration options.</param>
        public GuidCustomerContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
