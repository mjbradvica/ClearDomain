﻿// <copyright file="StringEntityIntegrationTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace ClearDomain.Tests.StringPrimary
{
    /// <summary>
    /// Integration tests for string entities.
    /// </summary>
    [TestClass]
    public class StringEntityIntegrationTests : BaseIntegrationTest
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

        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Dapper_CanBePersisted()
        {
            await TestHelpers.ClearSqlDatabase();

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestStringEntity();

                await connection.ExecuteAsync($"INSERT INTO dbo.StringEntities VALUES ('{entity.Id}');");

                await connection.CloseAsync();
            }
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Dapper_CanBeRetrieved()
        {
            await TestHelpers.ClearSqlDatabase();

            var id = Guid.NewGuid().ToString();

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestStringEntity(id);

                await connection.ExecuteAsync($"INSERT INTO dbo.StringEntities VALUES ('{entity.Id}');");

                await connection.CloseAsync();
            }

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var result = await connection.QueryFirstAsync<TestStringEntity>($"SELECT * FROM dbo.StringEntities WHERE Id='{id}';");

                await connection.CloseAsync();

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
            }
        }

        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_ADO_CanBePersisted()
        {
            await TestHelpers.ClearSqlDatabase();

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestStringEntity();

                var transaction = connection.BeginTransaction();

                var command = new SqlCommand($"INSERT INTO dbo.StringEntities VALUES ('{entity.Id}');", connection, transaction);

                await command.ExecuteNonQueryAsync();

                await transaction.CommitAsync();

                await connection.CloseAsync();
            }
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_ADO_CanBeRetrieved()
        {
            await TestHelpers.ClearSqlDatabase();

            var id = Guid.NewGuid().ToString();

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestStringEntity(id);

                var transaction = connection.BeginTransaction();

                var command = new SqlCommand($"INSERT INTO dbo.StringEntities VALUES ('{entity.Id}');", connection, transaction);

                await command.ExecuteNonQueryAsync();

                await transaction.CommitAsync();

                await connection.CloseAsync();
            }

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var command = new SqlCommand($"SELECT * FROM dbo.StringEntities WHERE Id='{id}';", connection);

                var response = await command.ExecuteReaderAsync();

                var entities = new List<TestStringEntity>();

                while (await response.ReadAsync())
                {
                    entities.Add(new TestStringEntity(response.GetString(0)));
                }

                var result = entities.First();

                await connection.CloseAsync();

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
            }
        }

        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Mongo_CanBePersisted()
        {
            var client = new MongoClient(TestHelpers.MongoConnectionString());

            var collection = client.GetDatabase("clear_domain").GetCollection<TestStringEntity>("string_entities");

            await collection.InsertOneAsync(new TestStringEntity());
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Mongo_CanBeRetrieved()
        {
            var id = Guid.NewGuid().ToString();

            var client = new MongoClient(TestHelpers.MongoConnectionString());

            var collection = client.GetDatabase("clear_domain").GetCollection<TestStringEntity>("string_entities");

            await collection.InsertOneAsync(new TestStringEntity(id));

            var filter = Builders<TestStringEntity>.Filter.Eq(x => x.Id, id);

            var result = await collection.FindAsync(filter);

            IEnumerable<TestStringEntity> results = new List<TestStringEntity>();

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
