using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReadModel.Features.Experts.Dtos;
using ReadModel.Features.Stats.Dtos;

namespace ReadModel.Features.Stats.Queries
{
    public class GetExpertStats: IRequest<IEnumerable<ExpertStatsReadDto>>
    {
        public int TourId { get; private set; }

        public GetExpertStats(int tourId)
        {
            TourId = tourId;
        }
    }
}
