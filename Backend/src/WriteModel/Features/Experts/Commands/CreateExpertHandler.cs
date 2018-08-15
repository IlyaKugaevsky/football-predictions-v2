using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;
using Persistence;

namespace WriteModel.Features.Experts.Commands
{
    public class CreateExpertHandler : IRequestHandler<CreateExpert, bool>
    {
        private readonly PredictionsContext _context;

        public CreateExpertHandler(PredictionsContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateExpert command,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var expert = new Expert(command.Nickname);
            await _context.Experts.AddAsync(expert, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }

}
