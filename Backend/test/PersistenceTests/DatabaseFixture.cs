using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Predictions.Domain.Models;
using Predictions.Persistence;
using Xunit;

namespace Predictions.PersistenceTests
{
    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<PredictionsContext>()
                .UseSqlite("Data Source=predictions_test.db")
                .Options;

            Context = new PredictionsContext(options);
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

        public DatabaseFixture(PredictionsContext context)
        {
            this.Context = context;

        }
        public PredictionsContext Context { get; private set; }

        public void SeedDatabase()
        {
            var tournament = new Tournament("test", DateTime.MinValue, DateTime.MaxValue);
            var tour = new Tour(1, DateTime.MinValue, DateTime.MaxValue);

            tournament.AddTour(tour);
        }
        public void Dispose()
        {
            Context.Database.EnsureDeleted();
        }
    }

}