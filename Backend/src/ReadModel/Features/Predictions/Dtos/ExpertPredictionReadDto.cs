using ReadModel.Features.Experts.Dtos;
using ReadModel.Features.Tournaments.Dtos;
using System.Collections.Generic;

namespace ReadModel.Features.Predictions.Dtos
{
    public class ExpertPredictionReadDto
    {
        public string Nickname {get; }

        public string HomeTeamTitle { get; }
        public string AwayTeamTitle { get; }
        public string PredictionValue {get; }

        public ExpertPredictionReadDto(string nickname, string homeTeamTitle, string awayTeamTitle, string predictionValue)
        {
            Nickname = nickname;
            HomeTeamTitle = homeTeamTitle;
            AwayTeamTitle = awayTeamTitle;
            PredictionValue = predictionValue;
        }
    }
}
