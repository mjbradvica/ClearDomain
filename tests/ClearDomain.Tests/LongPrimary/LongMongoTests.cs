// <copyright file="LongMongoTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace ClearDomain.Tests.LongPrimary
{
    /// <summary>
    /// Long entity integration tests.
    /// </summary>
    [TestClass]
    public class LongMongoTests : BaseMongoTest
    {
        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Mongo_CanBePersisted()
        {
            var client = new MongoClient(TestHelpers.MongoConnectionString());

            var collection = client.GetDatabase("clear_domain").GetCollection<TestLongEntity>("long_entities");

            await collection.InsertOneAsync(new TestLongEntity(1));
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Mongo_CanBeRetrieved()
        {
            const int id = 1;

            var client = new MongoClient(TestHelpers.MongoConnectionString());

            var collection = client.GetDatabase("clear_domain").GetCollection<TestLongEntity>("long_entities");

            await collection.InsertOneAsync(new TestLongEntity(id));

            var filter = Builders<TestLongEntity>.Filter.Eq(x => x.Id, id);

            var result = await collection.FindAsync(filter);

            IEnumerable<TestLongEntity> results = new List<TestLongEntity>();

            if (await result.MoveNextAsync())
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
