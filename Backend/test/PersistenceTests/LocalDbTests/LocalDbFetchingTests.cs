using System;
using System.Linq;
using Domain.Models;
using PersistenceTests.LocalDbTests.DbInitializers;
using Shouldly;
using Xunit;

namespace PersistenceTests.LocalDbTests
{
    [Collection("Database collection")]
    public class LocalDbFetchingTests
    {
        public LocalDbFetchingTests(DbFixture fixture)
        {
            IDbInitializer initializer
                = new JsonDbInitializer<Tournament>("Fixtures/Json/Tournaments.json");

            _fixture = fixture;
            _fixture.Seed(initializer);
        }

        private readonly DbFixture _fixture;

        [Fact]
        public void Should_Fetch_Tournaments_With_Nested_Entities_Correctly()
        {
            var tournaments = _fixture.Context.Tournaments.ToList();
            var tours = tournaments[0].Tours.ToList();
            var matches = tours[0].Matches.ToList();

            tournaments.Count.ShouldBe(2);
            tournaments[0].Title.ShouldBe("Tournament1");
            tournaments[0].StartDate.ShouldBe(DateTime.Parse("2017-09-12T21:45:00"));
            tournaments[0].EndDate.ShouldBe(DateTime.Parse("2018-05-27T00:00:00"));

            tours.Count.ShouldBe(2);
            matches.Count.ShouldBe(1);
            matches[0].Score.Value.ShouldBe("0:0");
        }
    }
}