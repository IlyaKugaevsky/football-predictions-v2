using System;

namespace WriteModel.Features.Tournaments.Dtos
{
    public class TournamentInfoWriteDto
    {
        public TournamentInfoWriteDto(string title, DateTime startDate, DateTime endDate)
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string Title { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}