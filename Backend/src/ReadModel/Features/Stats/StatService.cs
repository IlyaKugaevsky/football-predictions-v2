using Domain.Models;
using Domain.PointSystems;
using ReadModel.Features.Stats.Dtos;
using System.Collections.Generic;

namespace ReadModel.Features.Stats
{
    public class StatService
    {
        public IEnumerable<ExpertStatsReadDto> DenormalizePredictionResultsToDto(IReadOnlyDictionary<Expert, LegacyDbPredictionsResultAccumulator> predictionResultsByExpert, ICommonPointSystem commonPointSystem)
        {
            var stats = new List<ExpertStatsReadDto>();

            foreach (var expert in predictionResultsByExpert.Keys)
            {
                var expertResults = predictionResultsByExpert[expert];
                var sum = expertResults.PointSum;
                stats.Add(new ExpertStatsReadDto(expert, expertResults, sum));
            }

            return stats;
        }
    }
}
