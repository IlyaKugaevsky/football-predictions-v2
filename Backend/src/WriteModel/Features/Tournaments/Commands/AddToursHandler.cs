using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;
using Persistence;


namespace WriteModel.Features.Tournaments.Commands
{
    public class AddToursHandler: IRequestHandler<AddTours, bool>
    {
        private readonly PredictionsContext _context;

        public AddToursHandler(PredictionsContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddTours command,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournament = await _context.Tournaments.FindAsync(command.TournamentId);
            if (tournament == null)
            {
                return false;
            }

            var tours = command.Tours.Select(t => new Tour(t.TourNumber, t.StartDate, t.EndDate));

            tournament.AddTours(tours);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

    }
}
