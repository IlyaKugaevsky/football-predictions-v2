using MediatR;
using ReadModel.Features.Stats.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetExpertStats: IRequest<IEnumerable<ExpertStatsReadDto>>
    {
        public int TournamentId { get; private set; }
        public int TourNumber { get; private set; }

        public GetExpertStats(int tournamentId, int tourNumber)
        {
            TournamentId = tournamentId;
            TourNumber = tourNumber;
        }
    }
}
