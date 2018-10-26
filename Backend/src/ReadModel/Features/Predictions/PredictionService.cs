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
    public class PredictionService
    {
        public IReadOnlyDictionary<Expert, PredictionsResultAccumulator> GroupPredictionsResultsByExpert(IEnumerable<Match> matches)
        {
            var predictionResultsByExpert = new Dictionary<Expert, PredictionsResultAccumulator>();

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
                        predictionsResult.AddResult(prediction.Result);
                    }
                    else
                    {
                        var predictionsResult = new PredictionsResultAccumulator();
                        predictionsResult.AddResult(prediction.Result);

                        predictionResultsByExpert[expert] = predictionsResult;
                    }
                }
            }
            return predictionResultsByExpert;
        }

        public IReadOnlyDictionary<Expert, ICollection<Prediction>> GroupPredictionsByExpert(IEnumerable<Match> matches)
        {
            var predictionsByExpert = new Dictionary<Expert, ICollection<Prediction>>();

            foreach (var match in matches)
            {
                foreach (var prediction in match.Predictions.OrEmptyIfNull())
                {
                    var expert = prediction.Expert;

                    if (predictionsByExpert.ContainsKey(expert))
                    {
                        var expertPredictions = predictionsByExpert[expert];
                        expertPredictions.Add(prediction);
                    }
                    else
                    {
                        var predictions = new List<Prediction>();
                        predictions.Add(prediction);

                        predictionsByExpert[expert] = predictions;
                    }
                }
            }
            return predictionsByExpert;
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
