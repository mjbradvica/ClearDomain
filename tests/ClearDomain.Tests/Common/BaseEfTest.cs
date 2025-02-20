// <copyright file="BaseEfTest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ClearDomain.Tests.Common
{
    /// <inheritdoc />
    public abstract class BaseEfTest : IDisposable
    {
        private DbConnection? _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEfTest"/> class.
        /// </summary>
        protected BaseEfTest()
        {
            _connection = new SqliteConnection("DataSource=myshareddb;mode=memory;cache=shared");

            _connection.Open();

            ContextOptions = new DbContextOptionsBuilder().UseSqlite(_connection).Options;

            using (var context = new TestDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();
            }
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
