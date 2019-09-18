using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain.Models;
using Domain.Services;
using Newtonsoft.Json;
using Shouldly;
using Utils.Json;
using Xunit;

namespace DomainTests.ModelTests
{
    public class ExpertResultsAccumulatorTests
    {
        private readonly JsonSerializerSettings _settings;
        public ExpertResultsAccumulatorTests()
        {
            _settings = new JsonSerializerSettings
            {
                ContractResolver = new AllPropsAndFieldsContractResolver()
            };

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
            
            var expertResults = new ExpertsResultAccumulator(matches);

            var expertResultsTable = expertResults.ExpertsTable;
            
            
            expertResultsTable.Count.ShouldBe(2);

            expert1.Nickname.ShouldBe("Mike");
            expertResultsTable[expert1].Scores.ShouldBe(1);
            expertResultsTable[expert1].Differences.ShouldBe(1);
            expertResultsTable[expert1].Outcomes.ShouldBe(0);

            expert2.Nickname.ShouldBe("John");
            expertResultsTable[expert2].Scores.ShouldBe(0);
            expertResultsTable[expert2].Differences.ShouldBe(0);
            expertResultsTable[expert2].Outcomes.ShouldBe(1);
        }
    }
}