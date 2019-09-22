using System;
using Domain.Models;

namespace Domain.PointSystems
{
    public class DefaultPredictionPointSystem: ICommonPredictionPointSystem
    {
        public int OutcomeWeight => 1;
        public int DifferenceWeight => 2;
        public int ScoreWeight => 3;
    }

    //public class CommonThreePointSystem : IPointSystem
    //{
    //    public int ConvertToPoints(PredictionResult predictionResult)
    //    {
    //        switch (predictionResult)
    //        {
    //            case PredictionResult.NothingGuessed:
    //                return 0;

    //            case PredictionResult.OutcomeGuessed:
    //                return 1;

    //            case PredictionResult.DifferenceGuessed:
    //                return 2;

    //            case PredictionResult.ScoreGuessed:
    //                return 3;

    //            case PredictionResult.NotYetAssigned:
    //                throw new ArgumentException("PredictionResult is not assigned", nameof(predictionResult));

    //            default:
    //                throw new ArgumentOutOfRangeException(nameof(predictionResult), predictionResult, null);
    //        }
    //    }

    //}
}
