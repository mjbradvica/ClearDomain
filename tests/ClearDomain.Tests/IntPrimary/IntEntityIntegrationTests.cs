﻿// <copyright file="IntEntityIntegrationTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace ClearDomain.Tests.IntPrimary
{
    /// <summary>
    /// Int entity integration tests.
    /// </summary>
    [TestClass]
    public class IntEntityIntegrationTests : BaseIntegrationTest
    {
        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_EF_CanBePersisted()
        {
            await TestHelpers.ClearSqlDatabase();

            await using (var context = new TestDbContext())
            {
                await context.IntEntities.AddAsync(new TestIntEntity());

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
            await TestHelpers.ClearSqlDatabase();

            await using (var context = new TestDbContext())
            {
                await context.IntEntities.AddAsync(new TestIntEntity());

                await context.SaveChangesAsync();
            }

            await using (var context = new TestDbContext())
            {
                var result = await context.IntEntities.ToListAsync();

                Assert.IsNotNull(result.First());
                Assert.IsTrue(result.First().Id > 0);
            }
        }

        /// <summary>
        /// Ensures an identity user can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task IdentityUser_EF_CanBePersisted()
        {
            await TestHelpers.ClearSqlDatabase();

            await using (var context = new TestDbContext())
            {
                var user = new TestIntIdentityUser();

                await context.IntIdentityUsers.AddAsync(user);

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
            await TestHelpers.ClearSqlDatabase();

            await using (var context = new TestDbContext())
            {
                await context.IntIdentityUsers.AddAsync(new TestIntIdentityUser());

                await context.SaveChangesAsync();
            }

            await using (var context = new TestDbContext())
            {
                var result = await context.IntIdentityUsers.ToListAsync();

                Assert.IsNotNull(result.First());
                Assert.IsTrue(result.First().Id > 0);
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

                await connection.ExecuteAsync("SET IDENTITY_INSERT dbo.IntEntities ON; INSERT INTO dbo.IntEntities (Id) VALUES ('1');");

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

            const int id = 1;

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                await connection.ExecuteAsync($"SET IDENTITY_INSERT dbo.IntEntities ON; INSERT INTO dbo.IntEntities (Id) VALUES ('{id}');");

                await connection.CloseAsync();
            }

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var result = await connection.QueryFirstAsync<TestIntEntity>($"SELECT * FROM dbo.IntEntities WHERE Id='{id}';");

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

                var entity = new TestIntEntity(1);

                var transaction = connection.BeginTransaction();

                var command = new SqlCommand($"SET IDENTITY_INSERT dbo.IntEntities ON; INSERT INTO dbo.IntEntities (Id) VALUES ('{entity.Id}');", connection, transaction);

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

            const int id = 1;

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestIntEntity(id);

                var transaction = connection.BeginTransaction();

                var command = new SqlCommand($"SET IDENTITY_INSERT dbo.IntEntities ON; INSERT INTO dbo.IntEntities (Id) VALUES ('{entity.Id}');", connection, transaction);

                await command.ExecuteNonQueryAsync();

                await transaction.CommitAsync();

                await connection.CloseAsync();
            }

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var command = new SqlCommand($"SELECT * FROM dbo.IntEntities WHERE Id='{id}';", connection);

                var response = await command.ExecuteReaderAsync();

                var entities = new List<TestIntEntity>();

                while (await response.ReadAsync())
                {
                    entities.Add(new TestIntEntity(response.GetInt32(0)));
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

            var collection = client.GetDatabase("clear_domain").GetCollection<TestIntEntity>("int_entities");

            await collection.InsertOneAsync(new TestIntEntity(1));
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

            var collection = client.GetDatabase("clear_domain").GetCollection<TestIntEntity>("int_entities");

            await collection.InsertOneAsync(new TestIntEntity(id));

            var filter = Builders<TestIntEntity>.Filter.Eq(x => x.Id, id);

            var result = await collection.FindAsync(filter);

            IEnumerable<TestIntEntity> results = new List<TestIntEntity>();

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
