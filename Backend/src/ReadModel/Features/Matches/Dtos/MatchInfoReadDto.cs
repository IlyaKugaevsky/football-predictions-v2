using System;

namespace ReadModel.Features.Matches.Dtos
{
    public class MatchInfoReadDto
    {
        public MatchInfoReadDto(int id, DateTime date, string homeTeamTitle, string awayTeamTitle, string score)
        {
            Id = id;
            Date = date;
            HomeTeamTitle = homeTeamTitle;
            AwayTeamTitle = awayTeamTitle;
            Score = score;
        }

        public int Id { get; }
        public DateTime Date { get;  }
        public string HomeTeamTitle { get;  }
        public string AwayTeamTitle { get; }
        public string Score { get; }
    }
}