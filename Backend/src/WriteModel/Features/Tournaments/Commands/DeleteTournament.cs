using System;
using MediatR;
using WriteModel.Features.Tournaments.Dtos;

namespace WriteModel.Features.Tournaments.Commands
{
    public class DeleteTournament : IRequest<bool>
    {
        public DeleteTournament(int tournamentId)
        {
            TournamentId = tournamentId;
        }

        public int TournamentId { get; private set; }
    }
}