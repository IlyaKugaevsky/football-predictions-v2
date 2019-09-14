using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.FetchExtensions;
using ReadModel.Features.HeadToHead.Dtos;

namespace ReadModel.Features.HeadToHead.Queries
{
    public class GetHeadToHeadMatchesHandler: IRequestHandler<GetHeadToHeadMatches, IEnumerable<HeadToHeadMatchInfoReadDto>>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetHeadToHeadMatchesHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HeadToHeadMatchInfoReadDto>> Handle(GetHeadToHeadMatches request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var matches = await _context.HeadToHeadMatches.FetchWithExperts(FetchMode.ForRead).ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<HeadToHeadMatchInfoReadDto>>(matches);
        }
    }
}