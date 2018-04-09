using ReadModel.Features.Matches.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadModel.Features.Predictions.Dtos
{
    public class PredictionFullInfoReadDto
    {
        public PredictionFullInfoReadDto(MatchInfoReadDto matchInfo, string value, int sum, bool score, bool difference, bool outcome)
        {
            Matchinfo = matchInfo;
            Value = value;
            Sum = sum;
            Score = score;
            Difference = difference;
            Outcome = outcome;
        }

        public MatchInfoReadDto Matchinfo { get; private set; }

        public string Value { get; private set; }

        public int Sum { get; private set; }
        public bool Score { get; private set; }
        public bool Difference { get; private set; }
        public bool Outcome { get; private set; }

        public bool IsClosed { get; private set; }
    }
}
