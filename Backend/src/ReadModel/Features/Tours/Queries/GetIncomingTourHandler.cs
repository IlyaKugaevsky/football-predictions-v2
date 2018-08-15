using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using ReadModel.Features.Matches.Dtos;
using ReadModel.Features.Tours.Dtos;
using ReadModel.Features.Tours.Queries;

namespace ReadModel.Features.Tours.Queries
{
    public class GetIncomingTourHandler: IRequestHandler<GetIncomingTour, TourScheduleReadDto>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetIncomingTourHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TourScheduleReadDto> Handle(GetIncomingTour request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tour = await _context
                .Tours
                .FetchWithFullMatchesInfo(FetchMode.ForRead)
                .LastStartedAsync(cancellationToken);

            var tourInfo = _mapper.Map<TourInfoReadDto>(tour);
            var matchInfos = _mapper.Map<IEnumerable<MatchInfoReadDto>>(tour.Matches);

            return new TourScheduleReadDto(tourInfo, matchInfos);
        }
    }
}
