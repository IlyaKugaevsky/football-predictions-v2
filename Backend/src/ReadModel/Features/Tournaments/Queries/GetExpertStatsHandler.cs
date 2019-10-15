using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.PointSystems;
using MediatR;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using ReadModel.Features.Predictions;
using ReadModel.Features.Stats;
using ReadModel.Features.Stats.Dtos;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetExpertStatsHandler: IRequestHandler<GetExpertStats, IEnumerable<ExpertStatsInTourReadDto>>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;
        private readonly StatService _statService;
        private readonly PredictionService _predictionService;



        public GetExpertStatsHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _statService = new StatService();
            _predictionService = new PredictionService();
        }

        public async Task<IEnumerable<ExpertStatsInTourReadDto>> Handle(GetExpertStats request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournamentId = request.TournamentId;

            var tournament = await _context.Tournaments
                .FetchWithToursAndMatchesAndPredictionsAndExperts(FetchMode.ForRead)
                .WithIdAsync(tournamentId, cancellationToken);

            var tours = tournament.Tours.ToList();
            var expertStatsInTournament = new List<ExpertStatsInTourReadDto>();

            foreach (var tour in tours)
            {
                if (!tour.IsClosed) break;
                
                var matches = tour.Matches;
                var threePointSystem = new DefaultPredictionPointSystem();

                var predictionResultsByExpert = _predictionService.GroupPredictionsResultsByExpert(matches);
                var expertStats = _statService.DenormalizePredictionResultsToDto(predictionResultsByExpert, threePointSystem);
                expertStats = expertStats.OrderByDescending(es => es.Sum).ToList();
                
                var expertStatsInTour = new ExpertStatsInTourReadDto(tour.Number, expertStats);

                expertStatsInTournament.Add(expertStatsInTour);
            }

            return expertStatsInTournament;
        }
    }
}