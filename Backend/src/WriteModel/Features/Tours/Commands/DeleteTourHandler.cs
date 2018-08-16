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
    public class DeleteTourHandler : IRequestHandler<DeleteTour, bool>
    {
        private readonly PredictionsContext _context;
        public DeleteTourHandler(PredictionsContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteTour command,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tour = await _context.Tours.FindAsync(command.Id);

            _context.Remove(tour);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }

}
