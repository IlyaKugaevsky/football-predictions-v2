using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain.Models;
using Newtonsoft.Json;
using Shouldly;
using Utils.Json;
using Xunit;

namespace DomainTests.JsonDeserializationTests
{
    public class MatchDeserializationTests
    {
        private readonly JsonSerializerSettings _settings;

        public MatchDeserializationTests()
        {
            _settings = new JsonSerializerSettings
            {
                ContractResolver = new AllPropsAndFieldsContractResolver()
            };
        }

        [Fact]
        public void Should_Deserialize_Matches_Correctly()
        {
            var matchesJson = File.ReadAllText("Fixtures/Json/matches.json");

            var matches = JsonConvert.DeserializeObject<IEnumerable<Match>>(matchesJson, _settings).ToList();
            matches.Count.ShouldBe(2);

            var match1 = matches[0];
            var match2 = matches[1];

            match1.Predictions.ToList().Count.ShouldBe(2);
            match2.Predictions.ToList().Count.ShouldBe(2);

            match1.Predictions.ToList()[0].Score.ShouldBeTrue();
            match1.Predictions.ToList()[0].Difference.ShouldBeFalse();
            match1.Predictions.ToList()[0].Outcome.ShouldBeFalse();
            match1.Predictions.ToList()[0].Expert.Id.ShouldBe(1);
            match1.Predictions.ToList()[0].Expert.Nickname.ShouldBe("Mike");

            match1.Predictions.ToList()[1].Score.ShouldBeFalse();
            match1.Predictions.ToList()[1].Difference.ShouldBeFalse();
            match1.Predictions.ToList()[1].Outcome.ShouldBeTrue();
            match1.Predictions.ToList()[1].Expert.Id.ShouldBe(2);
            match1.Predictions.ToList()[1].Expert.Nickname.ShouldBe("John");

            match2.Predictions.ToList()[0].Score.ShouldBeFalse();
            match2.Predictions.ToList()[0].Difference.ShouldBeTrue();
            match2.Predictions.ToList()[0].Outcome.ShouldBeFalse();
            match2.Predictions.ToList()[0].Expert.Id.ShouldBe(1);
            match2.Predictions.ToList()[0].Expert.Nickname.ShouldBe("Mike");

            match2.Predictions.ToList()[1].Score.ShouldBeFalse();
            match2.Predictions.ToList()[1].Difference.ShouldBeFalse();
            match2.Predictions.ToList()[1].Outcome.ShouldBeFalse();
            match2.Predictions.ToList()[1].Expert.Id.ShouldBe(2);
            match2.Predictions.ToList()[1].Expert.Nickname.ShouldBe("John");
        }
    }
}
