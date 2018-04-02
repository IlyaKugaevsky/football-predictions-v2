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
        public IReadOnlyDictionary<Expert, PredictionsResult> EvaluatePredictionsResultsForExperts(IEnumerable<Match> matches)
        {
            var expertPredictions = new Dictionary<Expert, PredictionsResult>();

            foreach (var match in matches)
            {
                foreach (var prediction in match.Predictions.OrEmptyIfNull())
                {
                    if (!prediction.IsClosed)
                    {
                        expertPredictions.Clear();
                        throw new ArgumentException("All predictions must be closed.");
                    }

                    var expert = prediction.Expert;

                    if (expertPredictions.ContainsKey(expert))
                    {
                        var predictionsResult = expertPredictions[expert];
                        predictionsResult.Add(prediction);
                    }
                    else
                    {
                        var predictionsResult = new PredictionsResult();
                        predictionsResult.Add(prediction);

                        expertPredictions[expert] = predictionsResult;
                    }
                }
            }
            return expertPredictions;
        }
    }
}
