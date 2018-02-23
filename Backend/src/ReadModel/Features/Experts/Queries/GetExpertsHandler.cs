using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using ReadModel.Features.Experts.Dtos;

namespace ReadModel.Features.Experts.Queries
{
    public class GetExpertsHandler:
        IRequestHandler<GetExperts, IEnumerable<ExpertInfoReadDto>>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetExpertsHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExpertInfoReadDto>> Handle(GetExperts request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var experts = await _context.Experts.ToListAsync(cancellationToken: cancellationToken);
            return _mapper.Map<IEnumerable<ExpertInfoReadDto>>(experts);
        }

    }
}