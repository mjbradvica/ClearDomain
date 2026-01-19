// <copyright file="IntEfTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace ClearDomain.Tests.IntPrimary
{
    /// <inheritdoc />
    [TestClass]
    public class IntEfTests : BaseEfTest
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
                await context.IntEntities.AddAsync(new TestIntEntity(), TestContext.CancellationToken);

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
                await context.IntEntities.AddAsync(new TestIntEntity(), TestContext.CancellationToken);

                await context.SaveChangesAsync(TestContext.CancellationToken);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.IntEntities.ToListAsync(TestContext.CancellationToken);

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
                var user = new TestIntIdentityUser();

                await context.IntIdentityUsers.AddAsync(user, TestContext.CancellationToken);

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
                await context.IntIdentityUsers.AddAsync(new TestIntIdentityUser(), TestContext.CancellationToken);

                await context.SaveChangesAsync(TestContext.CancellationToken);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.IntIdentityUsers.ToListAsync(TestContext.CancellationToken);

                Assert.IsNotNull(result.First());
                Assert.IsGreaterThan(0, result.First().Id);
            }
        }
    }
}
