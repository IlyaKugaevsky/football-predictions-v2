using MediatR;
using ReadModel.Features.Stats.Dtos;
using System.Collections.Generic;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetExpertStatsByTourNumber: IRequest<IEnumerable<ExpertStatsReadDto>>
    {
        public int TournamentId { get; }
        public int TourNumber { get; }

        public GetExpertStatsByTourNumber(int tournamentId, int tourNumber)
        {
            TournamentId = tournamentId;
            TourNumber = tourNumber;
        }
    }
}
