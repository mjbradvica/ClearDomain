// <copyright file="LongEfTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace ClearDomain.Tests.LongPrimary
{
    /// <inheritdoc />
    [TestClass]
    public class LongEfTests : BaseEfTest
    {
        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task EntityEfCanBePersisted()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.LongEntities.AddAsync(new TestLongEntity(), TestContext.CancellationToken);

                await context.SaveChangesAsync(TestContext.CancellationToken);
            }
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task EntityEfCanBeRetrieved()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.LongEntities.AddAsync(new TestLongEntity(), TestContext.CancellationToken);

                await context.SaveChangesAsync(TestContext.CancellationToken);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.LongEntities.ToListAsync(TestContext.CancellationToken);

                Assert.IsNotNull(result.First());
                Assert.IsGreaterThan(0, result.First().Id);
            }
        }

        /// <summary>
        /// Ensures an identity user can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task IdentityUserEfCanBePersisted()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                var user = new TestLongIdentityUser();

                await context.LongIdentityUsers.AddAsync(user, TestContext.CancellationToken);

                await context.SaveChangesAsync(TestContext.CancellationToken);
            }
        }

        /// <summary>
        /// Ensures an identity user can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task IdentityUserEfCanBeRetrieved()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.LongIdentityUsers.AddAsync(new TestLongIdentityUser(), TestContext.CancellationToken);

                await context.SaveChangesAsync(TestContext.CancellationToken);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.LongIdentityUsers.ToListAsync(TestContext.CancellationToken);

                Assert.IsNotNull(result.First());
                Assert.IsGreaterThan(0, result.First().Id);
            }
        }
    }
}
