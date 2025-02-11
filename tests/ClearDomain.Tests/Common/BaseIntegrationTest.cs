// <copyright file="BaseIntegrationTest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Data.Common;
using ClearDomain.Tests.GuidPrimary;
using ClearDomain.Tests.IntPrimary;
using ClearDomain.Tests.LongPrimary;
using ClearDomain.Tests.StringPrimary;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace ClearDomain.Tests.Common
{
    /// <summary>
    /// Base class for integration tests.
    /// </summary>
    public abstract class BaseIntegrationTest : IDisposable
    {
        private DbConnection? _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIntegrationTest"/> class.
        /// </summary>
        protected BaseIntegrationTest()
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

            _connection = new SqliteConnection("DataSource=myshareddb;mode=memory;cache=shared");

            _connection.Open();

            ContextOptions = new DbContextOptionsBuilder().UseSqlite(_connection).Options;

            using (var context = new TestDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();
            }

            TestHelpers.ClearDatabase();
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        protected DbContextOptions ContextOptions { get; }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Cleans up managed resources.
        /// </summary>
        /// <param name="disposing">A value determining a proper dispose.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }
        }
    }
}
