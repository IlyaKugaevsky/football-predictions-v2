using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Predictions.Domain.Models;
using Predictions.Persistence;
using Predictions.PersistenceTests.LocalDbTests.DbInitializers;
using Shouldly;
using Xunit;

namespace Predictions.PersistenceTests.LocalDbTests
{
    [Collection("Database collection")]
    public class LocalDbFetchingTests
    {
        private DbFixture _fixture;
        public LocalDbFetchingTests(DbFixture fixture)
        {
            IDbInitializer initializer
                = new JsonDbInitializer<Tournament>("Fixtures/Json/Tournaments.json");

            _fixture = fixture;
            _fixture.Seed(initializer);
        }

        [Fact]
        public void Should_Fetch_Tournaments_With_Nested_Entities_Correctly()
        {
            var tournaments = _fixture.Context.Tournaments.ToList();
            var tours = tournaments[0].Tours.ToList();
            var matches = tours[0].Matches.ToList();

            tournaments.Count.ShouldBe(2);
            tours.Count.ShouldBe(2);
            matches.Count.ShouldBe(1);
            matches[0].Score.Value.ShouldBe("0:0");
        }
    }
}