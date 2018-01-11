using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence;
using Persistence.QueryExtensions;
using ReadModel.Features.Tournaments.Dtos;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetTournamentHandler : IRequestHandler<GetTournament, TournamentInfoReadDto>
    {
        private readonly PredictionsContext _context;

        public GetTournamentHandler(PredictionsContext context)
        {
            _context = context;
        }

        public async Task<TournamentInfoReadDto> Handle(GetTournament request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var id = request.TournamentId;
            var tournament = await _context.Tournaments.ByIdAsync(id);
            return Mapper.Map<TournamentInfoReadDto>(tournament);
        }
    }
}