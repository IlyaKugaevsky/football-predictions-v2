using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace WriteModel.Features.Tournaments.Commands
{
   public class DeleteTournamentHandler : IRequestHandler<DeleteTournament, bool>
   {
       private readonly PredictionsContext _context;
       public DeleteTournamentHandler(PredictionsContext context)
       {
           _context = context;
       }
       public async Task<bool> Handle(DeleteTournament command,
           CancellationToken cancellationToken = default(CancellationToken))
       {
           var tournament = await _context.Tournaments.FindAsync(command.TournamentId);

           _context.Remove(tournament); 

           return await _context.SaveChangesAsync(cancellationToken) > 0;
       }
   }
}