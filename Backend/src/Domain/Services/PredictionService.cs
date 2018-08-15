using System;
using System.Collections.Generic;
using Domain.Models;
using Utils.Common;

namespace Domain.Services
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

    }
}
