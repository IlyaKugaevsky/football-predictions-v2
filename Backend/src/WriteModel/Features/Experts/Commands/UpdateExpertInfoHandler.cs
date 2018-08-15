using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;
using Persistence;
using WriteModel.Features.Tournaments.Commands;

namespace WriteModel.Features.Experts.Commands
{
    public class UpdateExpertInfoHandler: IRequest<bool>
    {
        private readonly PredictionsContext _context;

        public UpdateExpertInfoHandler(PredictionsContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateTournamentInfo command,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournament = await _context.Tournaments.FindAsync(command.Id);

            tournament.UpdateInfo(command.Title, command.StartDate, command.EndDate);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

    }
}
