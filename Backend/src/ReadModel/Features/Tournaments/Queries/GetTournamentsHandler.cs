using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.FetchExtensions;
using ReadModel.Features.Tournaments.Dtos;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetTournamentsHandler :
        IRequestHandler<GetTournaments, IEnumerable<TournamentInfoReadDto>>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetTournamentsHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TournamentInfoReadDto>> Handle(GetTournaments request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournaments = await _context
                .Tournaments
                .Fetch(FetchMode.ForRead)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TournamentInfoReadDto>>(tournaments);
        }
    }
}