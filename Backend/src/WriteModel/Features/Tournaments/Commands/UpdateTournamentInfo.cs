using System;
using MediatR;

namespace WriteModel.Features.Tournaments.Commands
{
    public class UpdateTournamentInfo : IRequest<bool>
    {
        public UpdateTournamentInfo(int tournamentId, string title, DateTime startDate, DateTime endDate)
        {
            TournamentId = tournamentId;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int TournamentId { get; }
        public string Title { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}