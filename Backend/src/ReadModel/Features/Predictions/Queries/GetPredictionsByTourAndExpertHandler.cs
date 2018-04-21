using AutoMapper;
using MediatR;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using ReadModel.Features.Predictions.Dtos;
using Domain.QueryExtensions;
using System.Threading;
using System.Threading.Tasks;
using ReadModel.Features.Experts.Dtos;
using ReadModel.Features.Tournaments.Dtos;

namespace ReadModel.Features.Predictions.Queries
{
    public class GetPredictionsByTourAndExpertHandler : IRequestHandler<GetPredictionsByTourAndExpert, ExpertTourPredictionsReadDto>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;
        private readonly PredictionService _predictionService;

        public GetPredictionsByTourAndExpertHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _predictionService = new PredictionService();
        }

        public async Task<ExpertTourPredictionsReadDto> Handle(GetPredictionsByTourAndExpert request,
           CancellationToken cancellationToken = default(CancellationToken))
        {
            var tourId = request.TourId;
            var expertId = request.ExpertId;

            var tour = await _context
                .Tours
                .FetchWithFullMatchesInfoAndPredictions(FetchMode.ForRead)
                .WithIdAsync(tourId, cancellationToken);

            var tourNumber = tour.Number;
            var tournamentId = tour.TournamentId;

            var tournament = await _context.Tournaments.FindAsync(tournamentId);
            var expert = await _context.Experts.FindAsync(expertId);

            var predictions = tour.GetPredictionsForExpert(expertId);

            var expertInfo = _mapper.Map<ExpertInfoReadDto>(expert);
            var tournamentInfo = _mapper.Map<TournamentInfoReadDto>(tournament);
            var predictionInfos = _predictionService.ConvertToFullInfoDtos(predictions, _mapper);

            return new ExpertTourPredictionsReadDto(expertInfo, tournamentInfo, tourNumber, predictionInfos);
        }
    }
}
