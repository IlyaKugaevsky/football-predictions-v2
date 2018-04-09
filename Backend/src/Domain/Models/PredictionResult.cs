using Domain.PointSystems;
using System;
using System.Collections.Generic;
using System.Text;

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

        // In old database if guessed Score (Score equals true), then guessed everything (Difference and Outcome equals true)
        public void LegacyDbAdd(Prediction prediction)
        {
            if (prediction.Score) Scores++;
            else if (prediction.Difference) Differences++;
            else if (prediction.Outcome) Outcomes++;
        }

        public int GetPointsSum(IPointSystem pointSystem)
            => Outcomes * pointSystem.OutcomeWeight + Differences * pointSystem.DifferenceWeight + Scores * pointSystem.ScoreWeight;
    }
}
