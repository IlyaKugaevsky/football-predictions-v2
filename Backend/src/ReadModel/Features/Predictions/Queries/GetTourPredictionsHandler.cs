using AutoMapper;
using MediatR;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using ReadModel.Features.Predictions.Dtos;
using Domain.QueryExtensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReadModel.Features.Experts.Dtos;
using ReadModel.Features.Tournaments.Dtos;

namespace ReadModel.Features.Predictions.Queries
{
    public class GetTourPredictionsHandler : IRequestHandler<GetTourPredictions, IEnumerable<ExpertTourPredictionsReadDto>>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;
        private readonly PredictionService _predictionService;

        public GetTourPredictionsHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _predictionService = new PredictionService();
        }

        public async Task<IEnumerable<ExpertTourPredictionsReadDto>> Handle(GetTourPredictions request,
           CancellationToken cancellationToken = default(CancellationToken))
        {
            var tourId = request.TourId;

            var tour = await _context
                .Tours
                .FetchWithFullPredictionsInfo(FetchMode.ForRead)
                .WithIdAsync(tourId, cancellationToken);

            var tourNumber = tour.Number;
            var tournamentId = tour.TournamentId;
            var matches = tour.Matches;

            var tournament = await _context.Tournaments.FindAsync(tournamentId);

            var predictionsByExpert = _predictionService.GroupPredictionsByExpert(matches);

            var expertTourPredictions = new List<ExpertTourPredictionsReadDto>();

            foreach(var expert in predictionsByExpert.Keys)
            {
                var expertInfo = _mapper.Map<ExpertInfoReadDto>(expert);
                var tournamentInfo = _mapper.Map<TournamentInfoReadDto>(tournament);
                var predictionInfos = _predictionService.ConvertToFullInfoDtos(expert.Predictions, _mapper);
                
                expertTourPredictions.Add(new ExpertTourPredictionsReadDto(expertInfo, tournamentInfo, tourNumber, predictionInfos));
            }

            return expertTourPredictions;
        }
    }
}
