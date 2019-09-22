using Domain.PointSystems;
using MediatR;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using ReadModel.Features.Predictions;
using ReadModel.Features.Stats;
using ReadModel.Features.Stats.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetExpertStatsHandler: IRequestHandler<GetExpertStats, IEnumerable<ExpertStatsReadDto>>
    {
        private readonly PredictionsContext _context;
        private readonly PredictionService _predictionService;
        private readonly StatService _statService;

        public GetExpertStatsHandler(PredictionsContext context)
        {
            _context = context;
            _predictionService = new PredictionService();
            _statService = new StatService();
        }

        public async Task<IEnumerable<ExpertStatsReadDto>> Handle(GetExpertStats request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tourNumber = request.TourNumber;
            var tournamentId = request.TournamentId;

            var tourId = await _context.GetTourId(tourNumber, tournamentId, cancellationToken);

            var tour = await _context
                .Tours
                .FetchWithBasePredictionsInfo(FetchMode.ForRead)
                .WithIdAsync(tourId, cancellationToken);

            var matches = tour.Matches;
            var threePointSystem = new DefaultPredictionPointSystem();

            var predictionResultsByExpert = _predictionService.GroupPredictionsResultsByExpert(matches);
            var expertStats = _statService.DenormalizePredictionResultsToDto(predictionResultsByExpert, threePointSystem);

            return expertStats.OrderByDescending(s => s.Sum);
        }
    }
}
