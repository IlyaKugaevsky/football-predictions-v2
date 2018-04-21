using ReadModel.Features.Matches.Dtos;

namespace ReadModel.Features.Predictions.Dtos
{
    public class PredictionFullInfoReadDto
    {
        public PredictionFullInfoReadDto(MatchInfoReadDto matchInfo, PredictionMinimalInfoReadDto predictionInfo)
        {
            Matchinfo = matchInfo;
            PredictionInfo = predictionInfo;
        }

        public PredictionFullInfoReadDto(MatchInfoReadDto matchInfo)
        {
            Matchinfo = matchInfo;
        }

        public MatchInfoReadDto Matchinfo { get; }

        public PredictionMinimalInfoReadDto PredictionInfo { get; }
    }
}
