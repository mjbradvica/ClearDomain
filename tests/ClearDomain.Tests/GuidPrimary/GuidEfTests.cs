// <copyright file="GuidEfTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace ClearDomain.Tests.GuidPrimary
{
    /// <inheritdoc />
    [TestClass]
    public class GuidEfTests : BaseEfTest
    {
        /// <summary>
        /// Gets or sets the text context.
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
                await context.GuidEntities.AddAsync(new TestGuidEntity(Guid.NewGuid()), TestContext.CancellationToken);

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
            var id = Guid.NewGuid();

            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.GuidEntities.AddAsync(new TestGuidEntity(id), TestContext.CancellationToken);

                await context.SaveChangesAsync(TestContext.CancellationToken);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.GuidEntities.FirstOrDefaultAsync(x => x.Id == id, TestContext.CancellationToken);

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
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
                var user = new TestGuidIdentityUser
                {
                    Id = Guid.NewGuid(),
                };

                await context.GuidIdentityUsers.AddAsync(user, TestContext.CancellationToken);

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
            var id = Guid.NewGuid();

            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.GuidIdentityUsers.AddAsync(new TestGuidIdentityUser { Id = id }, TestContext.CancellationToken);

                await context.SaveChangesAsync(TestContext.CancellationToken);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.GuidIdentityUsers.FirstOrDefaultAsync(x => x.Id == id, TestContext.CancellationToken);

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
            }
        }
    }
}
