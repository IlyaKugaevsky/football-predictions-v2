using ReadModel.Features.Experts.Dtos;
using ReadModel.Features.Tournaments.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadModel.Features.Predictions.Dtos
{
    public class ExpertTourPredictionsReadDto
    {
        public ExpertInfoReadDto ExpertInfo {get; private set;}

        public TournamentInfoReadDto TournamentInfo{ get; private set; }
        public int TourNumber { get; private set; }

        public IEnumerable<PredictionFullInfoReadDto> Predictions { get; private set; }

        public ExpertTourPredictionsReadDto(ExpertInfoReadDto expertInfo, TournamentInfoReadDto tournamentInfo, int tourNumber, IEnumerable<PredictionFullInfoReadDto> predictions)
        {
            ExpertInfo = expertInfo;
            TournamentInfo = tournamentInfo;
            TourNumber = tourNumber;
            Predictions = predictions;
        }
    }
}
