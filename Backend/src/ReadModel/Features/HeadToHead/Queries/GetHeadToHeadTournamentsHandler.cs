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
    public class GetHeadToHeadTournamentsHandler : IRequestHandler<GetHeadToHeadTournaments, IEnumerable<HeadToHeadTournamentReadDto>>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetHeadToHeadTournamentsHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<HeadToHeadTournamentReadDto>> Handle(GetHeadToHeadTournaments request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournaments = await _context.HeadToHeadTournaments.Fetch(FetchMode.ForRead).ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<HeadToHeadTournamentReadDto>>(tournaments);
        }
    }
}