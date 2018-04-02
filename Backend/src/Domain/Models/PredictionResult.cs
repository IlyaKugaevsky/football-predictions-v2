using Domain.PointSystems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class PredictionsResult
    {
        public int Outcomes { get; private set; }
        public int Differences { get; private set; }
        public int Scores { get; private set; }

        public void Add(Prediction prediction)
        {
            if (prediction.Outcome) Outcomes++;
            if (prediction.Difference) Differences++;
            if (prediction.Score) Scores++;
        }

        public int GetSum(IPointSystem pointSystem)
            => Outcomes * pointSystem.OutcomeWeight + Differences * pointSystem.DifferenceWeight + Scores * pointSystem.ScoreWeight;
    }
}
