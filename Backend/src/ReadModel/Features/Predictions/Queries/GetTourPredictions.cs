using MediatR;
using System.Collections.Generic;
using ReadModel.Features.Predictions.Dtos;

namespace ReadModel.Features.Predictions.Queries
{
    public class GetTourPredictions : IRequest<IEnumerable<ExpertTourPredictionsReadDto>>
    {
        public int TourId { get; }

        public GetTourPredictions(int tourId)
        {
            TourId = tourId;
        }
    }
}
