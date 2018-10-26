using ReadModel.Features.Experts.Dtos;
using ReadModel.Features.Tournaments.Dtos;
using System.Collections.Generic;
using System.Text;
using System;


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

        public override string ToString()
        {
            var sbuilder = new StringBuilder($"{ExpertInfo.Nickname}{Environment.NewLine}");

            foreach (var prediction in Predictions)
            {
                var homeTeamTitle = prediction.Matchinfo.HomeTeamTitle;
                var awayTeamTitle = prediction.Matchinfo.AwayTeamTitle;
                var predictionValue = prediction.PredictionInfo.Value;
                sbuilder.Append($"{homeTeamTitle} - {awayTeamTitle} {predictionValue}{Environment.NewLine}");
            }

            return sbuilder.ToString();
        }
    }
}
