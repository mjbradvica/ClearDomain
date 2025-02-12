// <copyright file="StringAdoTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.StringPrimary
{
    /// <inheritdoc />
    [TestClass]
    public class StringAdoTests : BaseAdoTest
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
    }
}
