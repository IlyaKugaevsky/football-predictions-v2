using System;
using Domain.PointSystems;

namespace Domain.Models
{
    public class LegacyDbPredictionsResultAccumulator
    {
        public LegacyDbPredictionsResultAccumulator(int outcomes = 0, int differences = 0, int scores = 0)
        {
            Outcomes = outcomes;
            Differences = differences;
            Scores = scores;
        }

        public int Outcomes { get; private set; }
        public int Differences { get; private set; }
        public int Scores { get; private set; }
        public int PointSum { get; private set; }

        public void LegacyDbAdd(PredictionResult predictionResult)
        {
            switch (predictionResult)
            {
                case PredictionResult.NothingGuessed:
                    break;
                case PredictionResult.OutcomeGuessed:
                    Outcomes++;
                    break;
                case PredictionResult.DifferenceGuessed:
                    Differences++;
                    break;
                case PredictionResult.ScoreGuessed:
                    Scores++;
                    break;
                case PredictionResult.NotYetAssigned:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(predictionResult), predictionResult, null);
            }

            PointSum += PredictionResultConverter.FromThreePointSystem(predictionResult);



        }

        //public int GetPointsSum(IDeprecatedPointSystem deprecatedPointSystem)
        //    => Outcomes * deprecatedPointSystem.OutcomeWeight + Differences * deprecatedPointSystem.DifferenceWeight + Scores * deprecatedPointSystem.ScoreWeight;
    }
}
