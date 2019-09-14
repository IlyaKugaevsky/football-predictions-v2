using System.Collections.Generic;
using MediatR;
using ReadModel.Features.HeadToHead.Dtos;

namespace ReadModel.Features.HeadToHead.Queries
{
    public class GetHeadToHeadTournamentSchedule: IRequest<HeadToHeadTournamentScheduleReadDto>
    {
        public int TournamentId { get; }

        public GetHeadToHeadTournamentSchedule(int id)
        {
            TournamentId = id;
        }
    }
}