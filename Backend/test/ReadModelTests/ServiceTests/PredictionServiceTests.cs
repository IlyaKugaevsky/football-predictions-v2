using Domain.Models;
using Domain.Services;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Utils.Json;
using Xunit;

namespace ReadModelTests.ServiceTests
{
    public class PredictionServiceTests
    {
        private readonly JsonSerializerSettings _settings;
        private readonly PredictionService _predictionService;

        public PredictionServiceTests()
        {
            _settings = new JsonSerializerSettings
            {
                ContractResolver = new AllPropsAndFieldsContractResolver()
            };

            _predictionService = new PredictionService();
        }

        [Fact]
        public void Should_Evaluate_Predictions_Result_Correctly()
        {
            var matchesJson = File.ReadAllText("Fixtures/Json/matches.json");

            var matches = JsonConvert.DeserializeObject<IEnumerable<Match>>(matchesJson, _settings).ToList();
            var predictions = matches.SelectMany(m => m.Predictions).ToList();
            var experts = predictions.GroupBy(p => p.Expert).Select(g => g.Key).ToList();
            predictions.Count.ShouldBe(4);
            experts.Count.ShouldBe(2);

            var expert1 = experts[0];
            var expert2 = experts[1];

            var expertResults = _predictionService.GroupPredictionsResultsByExpert(matches);
            expertResults.Count().ShouldBe(2);

            expert1.Nickname.ShouldBe("Mike");
            expertResults[expert1].Scores.ShouldBe(1);
            expertResults[expert1].Differences.ShouldBe(1);
            expertResults[expert1].Outcomes.ShouldBe(0);

            expert2.Nickname.ShouldBe("John");
            expertResults[expert2].Scores.ShouldBe(0);
            expertResults[expert2].Differences.ShouldBe(0);
            expertResults[expert2].Outcomes.ShouldBe(1);
        }
    }
}
