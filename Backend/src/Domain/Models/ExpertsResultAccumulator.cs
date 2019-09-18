using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Utils.Common;

namespace Domain.Models
{
    public class ExpertsResultAccumulator
    {
        private readonly Dictionary<Expert, PredictionsResultAccumulator> _expertsTable = new Dictionary<Expert, PredictionsResultAccumulator>();

        public ExpertsResultAccumulator(IEnumerable<Match> matches)
        {
            AddMatches(matches);
        }

        public void AddMatch(Match match)
        {
            foreach (var prediction in match.Predictions.OrEmptyIfNull())
            {
                if (!prediction.IsClosed)
                {
                    _expertsTable.Clear();
                    throw new InvalidOperationException("All predictions must be closed.");
                }

                var expert = prediction.Expert;

                if (_expertsTable.ContainsKey(expert))
                {
                    var predictionsResult = _expertsTable[expert];
                    predictionsResult.AddResult(prediction.Result);
                }
                else
                {
                    var predictionsResult = new PredictionsResultAccumulator();
                    predictionsResult.AddResult(prediction.Result);

                    _expertsTable[expert] = predictionsResult;
                }
            }
        }

        public void AddMatches(IEnumerable<Match> matches)
        {
            foreach (var match in matches)
            {
                AddMatch(match);
            }
        }
        
        public IReadOnlyDictionary<Expert, PredictionsResultAccumulator> ExpertsTable => _expertsTable;
    }
}