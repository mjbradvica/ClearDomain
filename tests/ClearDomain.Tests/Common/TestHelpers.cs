// <copyright file="TestHelpers.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace ClearDomain.Tests.Common
{
    /// <summary>
    /// Test helpers.
    /// </summary>
    public static class TestHelpers
    {
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
