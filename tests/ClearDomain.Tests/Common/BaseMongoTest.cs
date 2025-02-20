// <copyright file="BaseMongoTest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.GuidPrimary;
using ClearDomain.Tests.IntPrimary;
using ClearDomain.Tests.LongPrimary;
using ClearDomain.Tests.StringPrimary;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace ClearDomain.Tests.Common
{
    /// <summary>
    /// Base class for integration tests.
    /// </summary>
    public abstract class BaseMongoTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMongoTest"/> class.
        /// </summary>
        protected BaseMongoTest()
        {
            BsonSerializer.TryRegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            if (!BsonClassMap.IsClassMapRegistered(typeof(TestGuidEntity)))
            {
                BsonClassMap.RegisterClassMap<TestGuidEntity>(map => { map.AutoMap(); });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(TestIntEntity)))
            {
                BsonClassMap.RegisterClassMap<TestIntEntity>(map => { map.AutoMap(); });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(TestLongEntity)))
            {
                BsonClassMap.RegisterClassMap<TestLongEntity>(map => { map.AutoMap(); });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(TestStringEntity)))
            {
                BsonClassMap.RegisterClassMap<TestStringEntity>(map => { map.AutoMap(); });
            }

            var client = new MongoClient(TestHelpers.MongoConnectionString());

            client.GetDatabase("clear_domain").GetCollection<TestGuidEntity>("guid_entities")
                .DeleteMany(Builders<TestGuidEntity>.Filter.Empty);
            client.GetDatabase("clear_domain").GetCollection<TestIntEntity>("int_entities")
                .DeleteMany(Builders<TestIntEntity>.Filter.Empty);
            client.GetDatabase("clear_domain").GetCollection<TestLongEntity>("long_entities")
                .DeleteMany(Builders<TestLongEntity>.Filter.Empty);
            client.GetDatabase("clear_domain").GetCollection<TestStringEntity>("string_entities")
                .DeleteMany(Builders<TestStringEntity>.Filter.Empty);
        }
    }
}
