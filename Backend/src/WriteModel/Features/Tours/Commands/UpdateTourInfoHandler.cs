using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using WriteModel.Features.Tournaments.Commands;

namespace WriteModel.Features.Tours.Commands
{
    public class UpdateTourInfoHandler : IRequestHandler<UpdateTourInfo, bool>
    {
        private readonly PredictionsContext _context;
        public UpdateTourInfoHandler(PredictionsContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateTourInfo command,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tour = await _context.Tours.FindAsync(command.Id);

            tour.UpdateInfo(command.Number, command.StartDate, command.EndDate);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
