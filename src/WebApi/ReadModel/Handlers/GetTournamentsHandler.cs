using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Predictions.Persistence;
using Predictions.Persistence.Entities;
using Predictions.WebApi.ReadModel.Queries;

namespace WebApi.ReadModel.Handlers
{
    public class GetTournamentsHandler : IRequestHandler<GetTournaments, string>
    {
        private readonly PredictionsContext _context;

        public GetTournamentsHandler(PredictionsContext context, IMediator mediator)
        {
            _context = context;
        }

        public Task<string> Handle(GetTournaments request, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult("Pong-pong mfucker!");
        }
    }

    // public class GetTournamentsHandler : AsyncRequestHandler<GetTournaments, string>
    // {
    //     private readonly PredictionsContext _context;

    //     public GetTournamentsHandler(PredictionsContext context)
    //     {
    //         _context = context;
    //     }

    //     public Task<string> Handle(GetTournaments request, 
    //         CancellationToken cancellationToken = default(CancellationToken))
    //     {
    //         return Task.FromResult("Pong-pong");
    //     }
    // }
}