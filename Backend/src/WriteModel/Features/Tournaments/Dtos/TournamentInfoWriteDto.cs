using System;

namespace Predictions.WriteModel.Features.Tournaments.Dtos
{
    public class TournamentInfoWriteDto
    {
        public TournamentInfoWriteDto(string title, DateTime startDate, DateTime endDate)
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}