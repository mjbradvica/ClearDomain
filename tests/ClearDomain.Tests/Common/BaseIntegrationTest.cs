// <copyright file="BaseIntegrationTest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.GuidPrimary;
using ClearDomain.Tests.IntPrimary;
using ClearDomain.Tests.LongPrimary;
using ClearDomain.Tests.StringPrimary;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace ClearDomain.Tests.Common
{
    /// <summary>
    /// Base class for integration tests.
    /// </summary>
    public class BaseIntegrationTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIntegrationTest"/> class.
        /// </summary>
        protected BaseIntegrationTest()
        {
            BsonSerializer.TryRegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            if (!BsonClassMap.IsClassMapRegistered(typeof(TestGuidEntity)))
            {
                BsonClassMap.RegisterClassMap<TestGuidEntity>(map =>
                {
                    map.AutoMap();
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(TestIntEntity)))
            {
                BsonClassMap.RegisterClassMap<TestIntEntity>(map =>
                {
                    map.AutoMap();
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(TestLongEntity)))
            {
                BsonClassMap.RegisterClassMap<TestLongEntity>(map =>
                {
                    map.AutoMap();
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(TestStringEntity)))
            {
                BsonClassMap.RegisterClassMap<TestStringEntity>(map =>
                {
                    map.AutoMap();
                });
            }

            TestHelpers.ClearDatabase();
        }
    }
}
