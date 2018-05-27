using Domain.Models;

namespace Domain.PointSystems
{
    public interface ICommonPointSystem
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
