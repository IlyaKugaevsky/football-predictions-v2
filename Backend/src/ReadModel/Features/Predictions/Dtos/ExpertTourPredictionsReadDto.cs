using ReadModel.Features.Experts.Dtos;
using ReadModel.Features.Tournaments.Dtos;
using System.Collections.Generic;

namespace ReadModel.Features.Predictions.Dtos
{
    public class ExpertTourPredictionsReadDto
    {
        public ExpertInfoReadDto ExpertInfo {get; }

        public TournamentInfoReadDto TournamentInfo{ get; }
        public int TourNumber { get; }

        public IEnumerable<PredictionFullInfoReadDto> Predictions { get; }

        public ExpertTourPredictionsReadDto(ExpertInfoReadDto expertInfo, TournamentInfoReadDto tournamentInfo, int tourNumber, IEnumerable<PredictionFullInfoReadDto> predictions)
        {
            ExpertInfo = expertInfo;
            TournamentInfo = tournamentInfo;
            TourNumber = tourNumber;
            Predictions = predictions;
        }
    }
}
