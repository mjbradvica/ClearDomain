// <copyright file="IntMongoTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using MongoDB.Driver;

namespace ClearDomain.Tests.IntPrimary
{
    /// <summary>
    /// Int entity integration tests.
    /// </summary>
    [TestClass]
    public class IntMongoTests : BaseMongoTest
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
        public async Task EntityMongoCanBePersisted()
        {
            var client = new MongoClient(TestHelpers.MongoConnectionString());

            var collection = client.GetDatabase("clear_domain").GetCollection<TestIntEntity>("int_entities");

            await collection.InsertOneAsync(new TestIntEntity(1), cancellationToken: TestContext.CancellationToken);
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task EntityMongoCanBeRetrieved()
        {
            const int id = 1;

            var client = new MongoClient(TestHelpers.MongoConnectionString());

            var collection = client.GetDatabase("clear_domain").GetCollection<TestIntEntity>("int_entities");

            await collection.InsertOneAsync(new TestIntEntity(id), cancellationToken: TestContext.CancellationToken);

            var filter = Builders<TestIntEntity>.Filter.Eq(x => x.Id, id);

            var result = await collection.FindAsync(filter, cancellationToken: TestContext.CancellationToken);

            IEnumerable<TestIntEntity> results = new List<TestIntEntity>();

            if (await result.MoveNextAsync(TestContext.CancellationToken))
            {
                results = result.Current;
            }

            foreach (var document in results)
            {
                Assert.IsNotNull(document);
                Assert.AreEqual(id, document.Id);
            }
        }
    }
}
