namespace ReadModel.Features.Predictions.Dtos
{
    public class PredictionMinimalInfoReadDto
    {
        public PredictionMinimalInfoReadDto(int id, int expertId, string value, int sum, bool score, bool difference, bool outcome, bool isClosed)
        {
            Id = id;
            ExpertId = expertId;
            Value = value;
            Sum = sum;
            Score = score;
            Difference = difference;
            Outcome = outcome;
            IsClosed = isClosed;
        }

        public int Id { get; }
        public int ExpertId { get; }
        public string Value { get; }

        public int Sum { get; }
        public bool Score { get; }
        public bool Difference { get; }
        public bool Outcome { get; }

        public bool IsClosed { get; }
    }

}
