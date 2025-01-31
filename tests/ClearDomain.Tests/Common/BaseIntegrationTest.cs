﻿// <copyright file="BaseIntegrationTest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.GuidPrimary;
using ClearDomain.Tests.IntPrimary;
using ClearDomain.Tests.LongPrimary;
using ClearDomain.Tests.StringPrimary;
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
            if (BsonSerializer.LookupSerializer(typeof(GuidSerializer)) == null)
            {
                BsonSerializer.TryRegisterSerializer(new GuidSerializer());
            }

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
