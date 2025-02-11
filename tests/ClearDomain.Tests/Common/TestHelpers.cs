// <copyright file="TestHelpers.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.GuidPrimary;
using ClearDomain.Tests.IntPrimary;
using ClearDomain.Tests.LongPrimary;
using ClearDomain.Tests.StringPrimary;
using Microsoft.Data.SqlClient;
using MongoDB.Driver;

namespace ClearDomain.Tests.Common
{
    /// <summary>
    /// Test helpers.
    /// </summary>
    public class TestHelpers
    {
        private static readonly Dictionary<string, string> Columns = new Dictionary<string, string>
        {
            { "GuidEntities", "uniqueidentifier" },
            { "IntEntities", "int" },
            { "LongEntities", "bigint" },
            { "StringEntities", "varchar(100)" },
        };

        /// <summary>
        /// Clears sql database.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task ClearSqlDatabase()
        {
            foreach (var pair in Columns)
            {
                await using (var connection = new SqlConnection(ConnectionString()))
                {
                    await connection.OpenAsync();

                    var command = new SqlCommand($"DROP TABLE IF EXISTS [dbo].[{pair.Key}];", connection);

                    await command.ExecuteNonQueryAsync();

                    await connection.CloseAsync();
                }

                await using (var connection = new SqlConnection(ConnectionString()))
                {
                    await connection.OpenAsync();

                    var sql = pair.Value.Contains("int") ? $"CREATE TABLE {pair.Key} (Id {pair.Value} IDENTITY(1,1) PRIMARY KEY);" : $"CREATE TABLE {pair.Key} (Id {pair.Value} NOT NULL PRIMARY KEY);";

                    var command = new SqlCommand(sql, connection);

                    await command.ExecuteNonQueryAsync();

                    await connection.CloseAsync();
                }
            }
        }

        /// <summary>
        /// Clears all test tables.
        /// </summary>
        public static void ClearDatabase()
        {
            var client = new MongoClient(MongoConnectionString());

            client.GetDatabase("clear_domain").GetCollection<TestGuidEntity>("guid_entities")
                .DeleteMany(Builders<TestGuidEntity>.Filter.Empty);
            client.GetDatabase("clear_domain").GetCollection<TestIntEntity>("int_entities")
                .DeleteMany(Builders<TestIntEntity>.Filter.Empty);
            client.GetDatabase("clear_domain").GetCollection<TestLongEntity>("long_entities")
                .DeleteMany(Builders<TestLongEntity>.Filter.Empty);
            client.GetDatabase("clear_domain").GetCollection<TestStringEntity>("string_entities")
                .DeleteMany(Builders<TestStringEntity>.Filter.Empty);
        }

        /// <summary>
        /// Gets the db connection string.
        /// </summary>
        /// <returns>The correct connection string.</returns>
        public static string ConnectionString()
        {
            return Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING") ??
                   "Server=.\\SQLExpress;Database=ClearDomain.Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";
        }

        /// <summary>
        /// Gets the Mongo connection string.
        /// </summary>
        /// <returns>The correct connection string.</returns>
        public static string MongoConnectionString()
        {
            return "mongodb://localhost:27017";
        }
    }
}
