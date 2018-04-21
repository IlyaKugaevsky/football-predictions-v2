using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Common;
using ReadModel.Features.Predictions.Dtos;
using AutoMapper;
using ReadModel.Features.Matches.Dtos;

namespace ReadModel.Features.Predictions
{
    class PredictionService
    {
        public IReadOnlyDictionary<Expert, LegacyDbPredictionsResultAccumulator> GroupPredictionsResultsByExpert(IEnumerable<Match> matches)
        {
            var predictionResultsByExpert = new Dictionary<Expert, LegacyDbPredictionsResultAccumulator>();

            foreach (var match in matches)
            {
                foreach (var prediction in match.Predictions.OrEmptyIfNull())
                {
                    if (!prediction.IsClosed)
                    {
                        predictionResultsByExpert.Clear();
                        throw new ArgumentException("All predictions must be closed.");
                    }

                    var expert = prediction.Expert;

                    if (predictionResultsByExpert.ContainsKey(expert))
                    {
                        var predictionsResult = predictionResultsByExpert[expert];
                        predictionsResult.LegacyDbAdd(prediction);
                    }
                    else
                    {
                        var predictionsResult = new LegacyDbPredictionsResultAccumulator();
                        predictionsResult.LegacyDbAdd(prediction);

                        predictionResultsByExpert[expert] = predictionsResult;
                    }
                }
            }
            return predictionResultsByExpert;
        }

        public IEnumerable<PredictionFullInfoReadDto> ConvertToFullInfoDtos(IEnumerable<Prediction> predictions, IMapper mapper)
        {
            return predictions.Select(p => new PredictionFullInfoReadDto(
                    mapper.Map<MatchInfoReadDto>(p.Match),
                    mapper.Map<PredictionMinimalInfoReadDto>(p)
                ));
        }
    }
}
