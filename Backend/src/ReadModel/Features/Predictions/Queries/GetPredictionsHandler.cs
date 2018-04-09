using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.FetchExtensions;
using ReadModel.Features.Predictions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadModel.Features.Predictions.Queries
{
    public class GetPredictionsHandler : IRequestHandler<GetPredictions, IEnumerable<PredictionMinimalInfoReadDto>>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetPredictionsHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PredictionMinimalInfoReadDto>> Handle(GetPredictions request,
           CancellationToken cancellationToken = default(CancellationToken))
        {
            var predictions = await _context
                .Predictions
                .Fetch(FetchMode.ForRead)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<PredictionMinimalInfoReadDto>>(predictions);
        }
    }
}
