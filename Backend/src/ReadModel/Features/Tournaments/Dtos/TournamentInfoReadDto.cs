using System;

namespace ReadModel.Features.Tournaments.Dtos
{
    public class TournamentInfoReadDto
    {
        public TournamentInfoReadDto(int id, string title, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Id { get; }
        public string Title { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get;  }
    }
}