using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using ReadModel.Features.Tournaments.Dtos;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetTournamentsHandler :
        IRequestHandler<GetTournaments, IEnumerable<TournamentInfoReadDto>>
    {
        private readonly PredictionsContext _context;

        public GetTournamentsHandler(PredictionsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TournamentInfoReadDto>> Handle(GetTournaments request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournaments = await _context.Tournaments.ToListAsync(cancellationToken: cancellationToken);
            return Mapper.Map<IEnumerable<TournamentInfoReadDto>>(tournaments);
        }
    }
}