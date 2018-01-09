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

namespace Predictions.WriteModel.Features.Tournaments.Commands
{
    // public class UpdateTournamentHandler: IRequestHandler<UpdateTournament, bool>
    // {
    //     private PredictionsContext _context;
    //     public UpdateTournamentHandler(PredictionsContext context)
    //     {
    //         _context = context;
    //     }
    //     public async Task<bool> Handle(UpdateTournament command, 
    //         CancellationToken cancellationToken = default(CancellationToken))
    //     {
    //         var tournament = await _context.FindAsync(command);
    //         var tournament = Mapper.Map<Tournament>(command.tournamentInfo);
    //         await _context.Tournaments.AddAsync(tournament);
    //         return (await _context.SaveChangesAsync() > 0);
    //     }
    // }
}