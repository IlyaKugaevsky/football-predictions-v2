using System;
using System.Collections.Generic;
using System.Text;

namespace ReadModel.Features.Predictions.Dtos
{
    public class PredictionMinimalInfoReadDto
    {
        public PredictionMinimalInfoReadDto(int id, string value, int sum, bool score, bool difference, bool outcome, bool isClosed)
        {
            Id = id;
            Value = value;
            Sum = sum;
            Score = score;
            Difference = difference;
            Outcome = outcome;
            IsClosed = isClosed;
        }

        public int Id { get; private set; }
        public string Value { get; private set; }

        public int Sum { get; private set; }
        public bool Score { get; private set; }
        public bool Difference { get; private set; }
        public bool Outcome { get; private set; }

        public bool IsClosed { get; private set; }
    }

}
