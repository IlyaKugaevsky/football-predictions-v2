using Predictions.Domain.Models;
using Predictions.Domain;

namespace Predictions.Domain.Models
{
    public class Prediction: Entity
    {
        protected Prediction() { }

        public Prediction(int expertId, int matchId, string value)
        {
            ExpertId = expertId;
            MatchId = matchId;
            Value = value;
        }

        public string Value { get; private set; }

        public int Sum { get; private set; } = 0;
        public bool Score { get; private set; } = false;
        public bool Difference { get; private set; } = false;
        public bool Outcome { get; private set; } = false;

        public bool IsClosed { get; private set; } = false;

        public int MatchId { get; private set; }
        public Match Match { get; private set; }

        public int ExpertId { get; private set; }
        public Expert Expert { get; private set; }
    }
}