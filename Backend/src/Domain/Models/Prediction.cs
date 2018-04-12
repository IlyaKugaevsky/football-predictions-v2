using Domain.PointSystems;

namespace Domain.Models
{
    public class Prediction : Entity
    {
        protected Prediction()
        {
        }

        internal Prediction(int id, string value, int sum, bool score, bool difference, bool outcome, bool isClosed)
        {
            Id = id;
            Value = value;
            Sum = sum;
            Score = score;
            Difference = difference;
            Outcome = outcome;
            IsClosed = isClosed;
        }

        internal void AttachMatch(Match match)
        {
            Match = match;
        }


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

        public int GetSum(IPointSystem pointSystem)
        {
            var sum = 0;

            if (Outcome) sum += pointSystem.OutcomeWeight;
            if (Difference) sum += pointSystem.DifferenceWeight;
            if (Score) sum += pointSystem.ScoreWeight;

            return sum;
        }
    }
}