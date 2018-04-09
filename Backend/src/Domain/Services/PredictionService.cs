using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Domain.PointSystems;
using Utils.Common;

namespace Domain.Services
{
    public class PredictionService
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
