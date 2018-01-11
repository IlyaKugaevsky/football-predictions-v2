using System.IO;
using System.Linq;
using Domain.Models;
using Newtonsoft.Json;
using Shouldly;
using Utils.Json;
using Xunit;

namespace DomainTests.JsonDeserializationTests
{
    public class TournamentDeserializationTests
    {
        public TournamentDeserializationTests()
        {
            _settings = new JsonSerializerSettings
            {
                ContractResolver = new AllPropsAndFieldsContractResolver()
            };
        }

        private readonly JsonSerializerSettings _settings;

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

            matches[0].Score.Value.ShouldBe("0:0");
        }
    }
}