using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Predictions.Persistence;
using Predictions.Domain.Models;
using Xunit;
using Shouldly;

namespace Predictions.PersistenceTests
{
    [Collection("Database collection")]
    public class DataFetchingTests
    {
        private DatabaseFixture _fixture;
        public DataFetchingTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            // var options = new DbContextOptionsBuilder<PredictionsContext>()
            //     .UseSqlite("Data Source=predictions_test.db")
            //     .Options;
        }

        [Fact]
        public void Something()
        {
            // var score = new FootballScore("1:0");
            // var match = new Match(1, 2, 3, DateTime.MinValue);

            var t = new Tournament("test", DateTime.MaxValue, DateTime.MaxValue);

            _fixture.Context.Tournaments.Add(t);
            _fixture.Context.SaveChanges();

            var x = 2 + 2;
            x.ShouldBe(4);
        }


    }
}