using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using ReadModel.Features.HeadToHead.Dtos;

namespace ReadModel.Features.HeadToHead.Queries
{
    public class GetHeadToHeadToursHandler: IRequestHandler<GetHeadToHeadTours, IEnumerable<HeadToHeadTourReadDto>>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetHeadToHeadToursHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<HeadToHeadTourReadDto>> Handle(GetHeadToHeadTours request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var tours = await _context.HeadToHeadTours.Fetch(FetchMode.ForRead).ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<HeadToHeadTourReadDto>>(tours);
        }
    }
}