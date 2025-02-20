// <copyright file="LongEfTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.LongPrimary
{
    /// <inheritdoc />
    [TestClass]
    public class LongEfTests : BaseEfTest
    {
        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_EF_CanBePersisted()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.LongEntities.AddAsync(new TestLongEntity());

                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_EF_CanBeRetrieved()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.LongEntities.AddAsync(new TestLongEntity());

                await context.SaveChangesAsync();
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.LongEntities.ToListAsync();

                Assert.IsNotNull(result.First());
                Assert.IsTrue(result.First().Id > 0);
            }
        }

        /// <summary>
        /// Ensures an identity user can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task IdentityUser_EF_CanBePersisted()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                var user = new TestLongIdentityUser();

                await context.LongIdentityUsers.AddAsync(user);

                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Ensures an identity user can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task IdentityUser_EF_CanBeRetrieved()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.LongIdentityUsers.AddAsync(new TestLongIdentityUser());

                await context.SaveChangesAsync();
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.LongIdentityUsers.ToListAsync();

                Assert.IsNotNull(result.First());
                Assert.IsTrue(result.First().Id > 0);
            }
        }
    }
}
