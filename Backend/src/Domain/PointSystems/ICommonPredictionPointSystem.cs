using Domain.Models;

namespace Domain.PointSystems
{
    public interface ICommonPredictionPointSystem
    {
        int OutcomeWeight { get; }
        int DifferenceWeight { get; }
        int ScoreWeight { get; }
    }

    //public interface IPointSystem
    //{
    //    int ConvertToPoints(PredictionResult predictionResult);
    //}
}
