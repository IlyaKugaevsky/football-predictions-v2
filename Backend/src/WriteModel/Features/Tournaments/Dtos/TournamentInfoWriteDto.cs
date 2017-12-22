using System;

namespace Predictions.WriteModel.Features.Tournaments.Dtos
{
    public class TournamentInfoWriteDto
    {
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}