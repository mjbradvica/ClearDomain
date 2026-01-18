// <copyright file="StringEfTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace ClearDomain.Tests.StringPrimary
{
    /// <inheritdoc />
    [TestClass]
    public class StringEfTests : BaseEfTest
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
                await context.StringEntities.AddAsync(new TestStringEntity(), TestContext.CancellationToken);

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
                await context.StringEntities.AddAsync(new TestStringEntity(), TestContext.CancellationToken);

                await context.SaveChangesAsync(TestContext.CancellationToken);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.StringEntities.ToListAsync(TestContext.CancellationToken);

                Assert.IsNotNull(result.First());
                Assert.AreNotEqual(Guid.Empty.ToString(), result.First().Id);
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
                var user = new TestStringIdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                };

                await context.StringIdentityUsers.AddAsync(user, TestContext.CancellationToken);

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
            var id = Guid.NewGuid().ToString();

            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.StringIdentityUsers.AddAsync(new TestStringIdentityUser { Id = id }, TestContext.CancellationToken);

                await context.SaveChangesAsync(TestContext.CancellationToken);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.StringIdentityUsers.FirstOrDefaultAsync(x => x.Id == id, TestContext.CancellationToken);

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
            }
        }
    }
}
