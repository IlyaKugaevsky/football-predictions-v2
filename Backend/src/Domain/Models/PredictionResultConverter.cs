using System;
using System.Collections.Generic;
using System.Text;
using Domain.QueryExtensions;

namespace Domain.Models
{
    public static class PredictionResultConverter
    {
        public static int FromThreePointSystem(PredictionResult predictionResult)
        {
            switch (predictionResult)
            {
                case PredictionResult.NothingGuessed:
                    return 0;

                case PredictionResult.OutcomeGuessed:
                    return 1;

                case PredictionResult.DifferenceGuessed:
                    return 2;

                case PredictionResult.ScoreGuessed:
                    return 3;

                case PredictionResult.NotYetAssigned:
                    throw new ArgumentException("PredictionResult is not assigned", nameof(predictionResult));

                default:
                    throw new ArgumentOutOfRangeException(nameof(predictionResult), predictionResult, null);
            }
        }
    }
}
