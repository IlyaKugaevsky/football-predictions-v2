using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using WriteModel.Features.Predictions.Commands;

namespace WriteModel.Features.HeadToHead.Commands
{
    public class EvaluateHeadToHeadTourHandler : IRequestHandler<EvaluateHeadToHeadTour, bool>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public EvaluateHeadToHeadTourHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(EvaluateHeadToHeadTour request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var headToHeadTourId = request.HeadToHeadTourId;
            var headToHeadTour = await _context.HeadToHeadTours.FetchWithEvaluationInfo(FetchMode.ForModify).WithIdAsync(headToHeadTourId, cancellationToken);
            
            headToHeadTour.Evaluate();
            return await _context.SaveChangesAsync(cancellationToken) >= 0;
        }
    }
}