// <copyright file="BaseAdoTest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.Data.SqlClient;

namespace ClearDomain.Tests.Common
{
    /// <summary>
    /// Base class for all ADO tests.
    /// </summary>
    public abstract class BaseAdoTest
    {
        private readonly Dictionary<string, string> _columns = new Dictionary<string, string>
        {
            { "GuidEntities", "uniqueidentifier" },
            { "IntEntities", "int" },
            { "LongEntities", "bigint" },
            { "StringEntities", "varchar(100)" },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAdoTest"/> class.
        /// </summary>
        protected BaseAdoTest()
        {
            foreach (var pair in _columns)
            {
                using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
                {
                    connection.Open();

                    var command = new SqlCommand($"DROP TABLE IF EXISTS [dbo].[{pair.Key}];", connection);

                    command.ExecuteNonQuery();

                    connection.Close();
                }

                using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
                {
                    connection.Open();

                    var sql = pair.Value.Contains("int") ? $"CREATE TABLE {pair.Key} (Id {pair.Value} IDENTITY(1,1) PRIMARY KEY);" : $"CREATE TABLE {pair.Key} (Id {pair.Value} NOT NULL PRIMARY KEY);";

                    var command = new SqlCommand(sql, connection);

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}
