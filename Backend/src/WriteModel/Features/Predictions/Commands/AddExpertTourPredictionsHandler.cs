using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Domain.QueryExtensions;
using Domain.Services;
using MediatR;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;

namespace WriteModel.Features.Predictions.Commands
{
    public class AddExpertTourPredictionsHandler: IRequestHandler<AddExpertTourPredictions, bool>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public AddExpertTourPredictionsHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddExpertTourPredictions request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var expertId = request.ExpertId;
            var tourId = request.TourId;
            var incomingPredictionsInfo = request.Predictions.ToList();

            var tour = await _context
                .Tours
                .FetchWitMatchesAndPredictions(FetchMode.ForModify)
                .WithIdAsync(tourId, cancellationToken);

            //if (tour.IsClosed) throw new InvalidOperationException("The tour is closed");

            var matches = tour.Matches;

            var expertPredictions = matches
                .SelectMany(m => m.Predictions)
                .Where(p => p.ExpertId == expertId)
                .ToList();

            foreach (var incomingPredictionInfo in incomingPredictionsInfo)
            {
                var expertPrediction = expertPredictions.SingleOrDefault(p => p.MatchId == incomingPredictionInfo.MatchId);

                if (expertPrediction == null)
                {
                    var score = FootballScoreProcessor.CreateScoreExpr(incomingPredictionInfo.HomeGoals,
                        incomingPredictionInfo.AwayGoals);
                    var prediction = new Prediction(expertId, incomingPredictionInfo.MatchId, score);
                    _context.Add(prediction);
                }
                else
                {
                    expertPrediction.SetScore(incomingPredictionInfo.HomeGoals, incomingPredictionInfo.AwayGoals);
                }
            }

            return await _context.SaveChangesAsync(cancellationToken) >= 0;
        }
    }
}
