using Domain.Models;

namespace ReadModel.Features.HeadToHead.Dtos
{
    public class HeadToHeadTableLineReadDto
    {
        public HeadToHeadTableLineReadDto(string expertNickname, LeagueTableLine leagueTableLine)
        {
            ExpertNickname = expertNickname;

            Games = leagueTableLine.Games;
            
            Wins = leagueTableLine.Wins;
            Draws = leagueTableLine.Draws;
            Loses = leagueTableLine.Loses;

            ScoredGoals = leagueTableLine.ScoredGoals;
            ConcededGoals = leagueTableLine.ConcededGoals;

            Points = leagueTableLine.Points;
        }
        public string ExpertNickname { get;  }
        
        public int Games { get; } 

        public int Wins { get; } 
        public int Draws { get; } 
        public int Loses { get; } 

        public int ScoredGoals { get;  } 
        public int ConcededGoals { get;  } 
        
        public int Points { get;  } 
    }
}