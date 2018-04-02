using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Stats
{
    public class ExpertTourPredictionResults
    {
        public ExpertTourPredictionResults(int expertId, string nickname,
            int outcomes, int differences, int scores, int sumPoints)
        {
            ExpertId = expertId;
            Nickname = nickname;

            Outcomes = outcomes;
            Differences = differences;
            Scores = scores;
            SumPoints = sumPoints;
        }

        public int ExpertId { get; private set; }
        public string Nickname { get; private set; }

        public int Outcomes { get; private set; }
        public int Differences { get; private set; }
        public int Scores { get; private set; }
        public int SumPoints { get; private set; }
    }
}
