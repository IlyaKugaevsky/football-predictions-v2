using System.Collections.Generic;
using MediatR;
using ReadModel.Features.Stats.Dtos;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetExpertStats: IRequest<IEnumerable<ExpertStatsInTourReadDto>>
    {
        public  int TournamentId { get; }

        public GetExpertStats(int tournamentId)
        {
            TournamentId = tournamentId;
        }
    }
}