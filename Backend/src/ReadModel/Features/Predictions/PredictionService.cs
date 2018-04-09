using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Common;

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
    }
}
