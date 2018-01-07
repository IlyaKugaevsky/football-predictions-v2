using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Predictions.Persistence;
using Predictions.Persistence.QueryExtensions;
using Predictions.Domain.Models;
using Predictions.ReadModel.Features.Tournaments.Dtos;

namespace Predictions.ReadModel.Features.Tournaments.Queries
{
    public class GetTournamentHandler : IRequestHandler<GetTournament, TournamentInfoReadDto>
    {
        private readonly PredictionsContext _context;

        public GetTournamentHandler(PredictionsContext context, IMediator mediator)
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