using System.Collections.Generic;
using MediatR;
using ReadModel.Features.Stats.Dtos;

namespace ReadModel.Features.Stats.Queries
{
    public class GetExpertStats: IRequest<IEnumerable<ExpertStatsReadDto>>
    {
        public int TourId { get; }

        public GetExpertStats(int tourId)
        {
            TourId = tourId;
        }
    }
}
