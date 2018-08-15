//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using MediatR;
//using Persistence;

//namespace WriteModel.Features.Experts.Commands
//{
//    public class DeleteExpertHandler : IRequestHandler<Tours.Commands.DeleteExpert, bool>
//    {
//        private readonly PredictionsContext _context;
//        public DeleteExpertHandler(PredictionsContext context)
//        {
//            _context = context;
//        }
//        public async Task<bool> Handle(Tours.Commands.DeleteExpert command,
//            CancellationToken cancellationToken = default(CancellationToken))
//        {
//            var expert = await _context.Experts.FindAsync(command.Id);

//            _context.Remove(expert);

//            return await _context.SaveChangesAsync(cancellationToken) > 0;
//        }
//    }
//}
