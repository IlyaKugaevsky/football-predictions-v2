using System;
using System.Collections.Generic;
using System.Text;

namespace WriteModel.Features.Predictions.Dtos
{
    public class PredictionWriteDto
    {
        public PredictionWriteDto(int matchId, int expertId, int homeGoals, int awayGoals)
        {
            MatchId = matchId;
            ExpertId = expertId;
            HomeGoals = homeGoals;
            AwayGoals = awayGoals;
        }

        public int MatchId { get; }
        public int ExpertId { get; }
        public int HomeGoals { get; }
        public int AwayGoals { get; }
    }
}
