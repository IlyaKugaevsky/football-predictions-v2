using Domain.Models;
using Domain.PointSystems;
using ReadModel.Features.Stats.Dtos;
using System.Collections.Generic;

namespace ReadModel.Features.Stats
{
    public class StatService
    {
        public IEnumerable<ExpertStatsReadDto> DenormalizePredictionResultsToDto(IReadOnlyDictionary<Expert, LegacyDbPredictionsResultAccumulator> predictionResultsByExpert, IPointSystem pointSystem)
        {
            var stats = new List<ExpertStatsReadDto>();

            foreach (var expert in predictionResultsByExpert.Keys)
            {
                var predictionResult = predictionResultsByExpert[expert];
                var sum = predictionResult.GetPointsSum(pointSystem);

                stats.Add(new ExpertStatsReadDto(expert, predictionResult, sum));
            }

            return stats;
        }
    }
}
