using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using WriteModel.Features.Experts.Commands;

namespace WriteModel.Features.Tournaments.Commands
{
   public class UpdateTournamentInfoHandler : IRequestHandler<UpdateExpertInfo, bool>
   {
       private readonly PredictionsContext _context;
       public UpdateTournamentInfoHandler(PredictionsContext context)
       {
           _context = context;
       }
       public async Task<bool> Handle(UpdateExpertInfo command,
           CancellationToken cancellationToken = default(CancellationToken))
       {
           var expert = await _context.Experts.FindAsync(command.Id);

           expert.UpdateInfo(command.Nickname);
           return await _context.SaveChangesAsync(cancellationToken) > 0;
       }
   }
}