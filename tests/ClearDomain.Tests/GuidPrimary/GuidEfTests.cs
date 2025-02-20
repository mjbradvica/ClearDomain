// <copyright file="GuidEfTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.GuidPrimary
{
    /// <inheritdoc />
    [TestClass]
    public class GuidEfTests : BaseEfTest
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
                await context.GuidEntities.AddAsync(new TestGuidEntity(Guid.NewGuid()));

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
            var id = Guid.NewGuid();

            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.GuidEntities.AddAsync(new TestGuidEntity(id));

                await context.SaveChangesAsync();
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.GuidEntities.FindAsync(id);

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
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
                var user = new TestGuidIdentityUser
                {
                    Id = Guid.NewGuid(),
                };

                await context.GuidIdentityUsers.AddAsync(user);

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
            var id = Guid.NewGuid();

            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.GuidIdentityUsers.AddAsync(new TestGuidIdentityUser { Id = id });

                await context.SaveChangesAsync();
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.GuidIdentityUsers.FindAsync(id);

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
            }
        }
    }
}
