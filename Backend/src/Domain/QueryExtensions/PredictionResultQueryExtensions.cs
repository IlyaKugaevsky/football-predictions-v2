using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Domain.PointSystems;

namespace Domain.QueryExtensions
{
    public static class PredictionResultQueryExtensions
    {
        public static bool IsValid(this PredictionResult predictionResult)
            => predictionResult < PredictionResult.NotYetAssigned || predictionResult > PredictionResult.ScoreGuessed;

        public static bool IsAssigned(this PredictionResult predictionResult)
            => predictionResult != PredictionResult.NotYetAssigned;
    }
}
