// <copyright file="IntAdoTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.IntPrimary
{
    /// <inheritdoc />
    [TestClass]
    public class IntAdoTests : BaseAdoTest
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
    }
}
