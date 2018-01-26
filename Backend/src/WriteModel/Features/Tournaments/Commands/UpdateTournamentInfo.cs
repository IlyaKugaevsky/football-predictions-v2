using System;
using MediatR;
using WriteModel.Features.Tournaments.Dtos;

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

        public int TournamentId { get; private set; }
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}