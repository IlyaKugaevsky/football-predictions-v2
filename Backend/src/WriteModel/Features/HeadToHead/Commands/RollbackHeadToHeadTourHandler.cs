using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;

namespace WriteModel.Features.HeadToHead.Commands
{
    public class RollbackHeadToHeadTourHandler: IRequestHandler<RollbackHeadToHeadTour, bool>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public RollbackHeadToHeadTourHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RollbackHeadToHeadTour request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var headToHeadTourId = request.HeadToHeadTourId;
            var headToHeadTour = await _context.HeadToHeadTours.FetchWithMatches(FetchMode.ForModify).WithIdAsync(headToHeadTourId, cancellationToken);
            
            headToHeadTour.Rollback();
            return await _context.SaveChangesAsync(cancellationToken) >= 0;
        }
    }
}