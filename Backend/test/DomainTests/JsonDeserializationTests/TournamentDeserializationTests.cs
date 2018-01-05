using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Predictions.Domain.Models;
using Shouldly;
using Xunit;

namespace Predictions.DomainTests.JsonDeserializationTests
{
    public class TournamentDeserializationTests
    {
        private JsonSerializerSettings _settings;
        public TournamentDeserializationTests()
        {
            _settings = new JsonSerializerSettings()
            {
                ContractResolver = new AllPropsAndFieldsContractResolver()
            };
        }

        [Fact]
        public void Should_Deserialize_Tournament_Correctly()
        {
            var tournamentJson = File.ReadAllText("Fixtures/Json/tournament.json");

            var tournament = JsonConvert.DeserializeObject<Tournament>(tournamentJson, _settings);
            var tours = tournament.Tours.ToList();
            var matches = tours[0].Matches.ToList();

            tournament.Title.ShouldBe("testTournament");

            tours.Count.ShouldBe(2);
            tours[0].Number.ShouldBe(1);
            tours[1].Number.ShouldBe(2);

            matches[0].HomeTeamId.ShouldBe(1);
            matches[1].HomeTeamId.ShouldBe(2);

            matches[0].Score.ScoreValue.ShouldBe("0:0");
        }
    }
}