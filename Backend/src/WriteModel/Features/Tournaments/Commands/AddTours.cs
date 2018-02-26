using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using WriteModel.Features.Tours.Dtos;

namespace WriteModel.Features.Tournaments.Commands
{
    public class AddTours: IRequest<bool>
    {
        public AddTours(int tournamentId, IEnumerable<TourInfoWriteDto> tours)
        {
            TournamentId = tournamentId;
            Tours = tours;
        }

        public int TournamentId { get; private set; }
        public IEnumerable<TourInfoWriteDto> Tours { get; private set; }
    }
}
