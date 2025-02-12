// <copyright file="LongAdoTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.LongPrimary
{
    /// <inheritdoc />
    [TestClass]
    public class LongAdoTests : BaseAdoTest
    {
        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Dapper_CanBePersisted()
        {
            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                await connection.ExecuteAsync("SET IDENTITY_INSERT dbo.LongEntities ON; INSERT INTO dbo.LongEntities (Id) VALUES ('1');");

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
            const int id = 1;

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                await connection.ExecuteAsync($"SET IDENTITY_INSERT dbo.LongEntities ON; INSERT INTO dbo.LongEntities (Id) VALUES ('{id}');");

                await connection.CloseAsync();
            }

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var result = await connection.QueryFirstAsync<TestLongEntity>($"SELECT * FROM dbo.LongEntities WHERE Id='{id}';");

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
            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestLongEntity(1);

                var transaction = connection.BeginTransaction();

                var command = new SqlCommand($"SET IDENTITY_INSERT dbo.LongEntities ON; INSERT INTO dbo.LongEntities (Id) VALUES ('{entity.Id}');", connection, transaction);

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
            const int id = 1;

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestLongEntity(id);

                var transaction = connection.BeginTransaction();

                var command = new SqlCommand($"SET IDENTITY_INSERT dbo.LongEntities ON; INSERT INTO dbo.LongEntities (Id) VALUES ('{entity.Id}');", connection, transaction);

                await command.ExecuteNonQueryAsync();

                await transaction.CommitAsync();

                await connection.CloseAsync();
            }

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var command = new SqlCommand($"SELECT * FROM dbo.LongEntities WHERE Id='{id}';", connection);

                var response = await command.ExecuteReaderAsync();

                var entities = new List<TestLongEntity>();

                while (await response.ReadAsync())
                {
                    entities.Add(new TestLongEntity(response.GetInt64(0)));
                }

                var result = entities.First();

                await connection.CloseAsync();

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
            }
        }
    }
}
