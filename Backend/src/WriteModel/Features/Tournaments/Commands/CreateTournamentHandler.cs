using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;
using Persistence;

namespace WriteModel.Features.Tournaments.Commands
{
    public class CreateTournamentHandler : IRequestHandler<CreateTournament, bool>
    {
        private readonly PredictionsContext _context;

        public CreateTournamentHandler(PredictionsContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateTournament command,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournament = new Tournament(command.Title, command.StartDate, command.EndDate);
            await _context.Tournaments.AddAsync(tournament, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}