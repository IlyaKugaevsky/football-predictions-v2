using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using ReadModel.Features.Tournaments.Dtos;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetTournamentHandler : IRequestHandler<GetTournament, TournamentInfoReadDto>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetTournamentHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TournamentInfoReadDto> Handle(GetTournament request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournamentId = request.TournamentId;
            var tournament = await _context
                .Tournaments
                .Fetch(FetchMode.ForRead)
                .WithIdAsync(tournamentId, cancellationToken);

            return _mapper.Map<TournamentInfoReadDto>(tournament);
        }
    }
}