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
using Predictions.Domain.Models;
using Predictions.ReadModel.Features.Tournaments.Dtos;

namespace Predictions.ReadModel.Features.Tournaments.Queries
{
    public class GetTournamentsHandler: 
        IRequestHandler<GetTournaments, IEnumerable<TournamentInfoReadDto>>
    {
        private readonly PredictionsContext _context;

        public GetTournamentsHandler(PredictionsContext context, IMediator mediator)
        {
            _context = context;
        }

        public async Task<IEnumerable<TournamentInfoReadDto>> Handle(GetTournaments request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournaments = await _context.Tournaments.ToListAsync();
            return Mapper.Map<IEnumerable<TournamentInfoReadDto>>(tournaments);
        }
    }
}