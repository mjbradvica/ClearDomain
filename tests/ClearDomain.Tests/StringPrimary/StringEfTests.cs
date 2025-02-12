// <copyright file="StringEfTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.StringPrimary
{
    /// <inheritdoc />
    [TestClass]
    public class StringEfTests : BaseEfTest
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
                await context.StringEntities.AddAsync(new TestStringEntity());

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
                await context.StringEntities.AddAsync(new TestStringEntity());

                await context.SaveChangesAsync();
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.StringEntities.ToListAsync();

                Assert.IsNotNull(result.First());
                Assert.AreNotEqual(Guid.Empty.ToString(), result.First().Id);
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
                var user = new TestStringIdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                };

                await context.StringIdentityUsers.AddAsync(user);

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
            var id = Guid.NewGuid().ToString();

            await using (var context = new TestDbContext(ContextOptions))
            {
                await context.StringIdentityUsers.AddAsync(new TestStringIdentityUser { Id = id });

                await context.SaveChangesAsync();
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var result = await context.StringIdentityUsers.FindAsync(id);

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
            }
        }
    }
}
