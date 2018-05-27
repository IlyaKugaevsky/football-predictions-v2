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

        //public static int GetPoints(this PredictionResult predictionResult, Func<PredictionResult, int> fromPointSystem) 
        //    => fromPointSystem(predictionResult);

        //public static int EvaluatePoints(this PredictionResult predictionResult, IPointSystem pointSystem) 
        //    => pointSystem.ConvertToPoints(predictionResult);
    }
}
