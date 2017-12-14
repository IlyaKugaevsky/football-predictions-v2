using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
// using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Predictions.Persistence;
using Predictions.Persistence.Entities;
using Predictions.ReadModel.Queries;

namespace Predictions.ReadModel.Handlers
{
    public class GetTournamentsHandler : IRequestHandler<GetTournaments, IEnumerable<Tournament>>
    {
        private readonly PredictionsContext _context;

        public GetTournamentsHandler(PredictionsContext context, IMediator mediator)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tournament>> Handle(GetTournaments request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _context.Tournaments.ToListAsync();
        }
    }
}