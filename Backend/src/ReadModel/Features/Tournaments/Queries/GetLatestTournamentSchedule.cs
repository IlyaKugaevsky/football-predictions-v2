using MediatR;
using ReadModel.Features.Tournaments.Dtos;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetLatestTournamentSchedule : IRequest<TournamentScheduleDto>
    {
    }
}