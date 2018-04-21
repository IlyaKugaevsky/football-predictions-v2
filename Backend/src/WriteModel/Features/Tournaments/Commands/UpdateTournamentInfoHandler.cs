using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace WriteModel.Features.Tournaments.Commands
{
   public class UpdateTournamentInfoHandler : IRequestHandler<UpdateTournamentInfo, bool>
   {
       private readonly PredictionsContext _context;
       public UpdateTournamentInfoHandler(PredictionsContext context)
       {
           _context = context;
       }
       public async Task<bool> Handle(UpdateTournamentInfo command,
           CancellationToken cancellationToken = default(CancellationToken))
       {
           var tournament = await _context.Tournaments.FindAsync(command.TournamentId);

           tournament.UpdateInfo(command.Title, command.StartDate, command.EndDate);
           return await _context.SaveChangesAsync(cancellationToken) > 0;
       }
   }
}