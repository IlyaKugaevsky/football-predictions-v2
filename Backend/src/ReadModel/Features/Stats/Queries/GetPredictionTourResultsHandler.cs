using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using MediatR;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using ReadModel.Features.Experts.Dtos;
using ReadModel.Features.Stats.Queries;

namespace ReadModel.Features.Stats.Queries
{
    //class GetTourPredictionResultsHandler: IRequestHandler<GetTourPredictionResults, IEnumerable<ExpertTourResultsReadDto>>
    //{
    //    private readonly PredictionsContext _context;
    //    private readonly IMapper _mapper;

    //    public GetTourPredictionResultsHandler(PredictionsContext context, IMapper mapper)
    //    {
    //        _context = context;
    //        _mapper = mapper;
    //    }

    //    public async Task<IEnumerable<ExpertTourResultsReadDto>> Handle(GetTourPredictionResults request,
    //        CancellationToken cancellationToken = default(CancellationToken))
    //    {

    //        var tour = (await _context.Tours.FetchWithMatchesAndPredictionsAndExperts().ByIdAsync(request.TourId)) as Tour;
    //        var matches = tour.Matches;

    //        var groupedPredictions = matches.SelectMany(m => m.Predictions).GroupBy(p => p.Expert).OrderBy(e => e.Key.Predictions.Sum(p => p.Sum));

    //    }
    //}
}
