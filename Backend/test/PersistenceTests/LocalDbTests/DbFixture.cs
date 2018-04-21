using System;
using Microsoft.EntityFrameworkCore;
using Persistence;
using PersistenceTests.LocalDbTests.DbInitializers;
using Xunit;

namespace PersistenceTests.LocalDbTests
{
    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    public class DbFixture : IDisposable
    {
        public DbFixture()
        {
            var options = new DbContextOptionsBuilder<PredictionsContext>()
                .UseSqlite("Data Source=predictions_test.db")
                .Options;

            Context = new PredictionsContext(options);
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

        public DbFixture(PredictionsContext context)
        {
            Context = context;
        }

        public PredictionsContext Context { get; }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
        }

        public void Seed(IDbInitializer initializer)
        {
            initializer.SeedDatabase(Context);
        }
    }
}