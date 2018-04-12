using MediatR;
using ReadModel.Features.Predictions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadModel.Features.Predictions.Queries
{
    public class GetPredictionsByTourAndExpert : IRequest<ExpertTourPredictionsReadDto>
    {
        public int TourId { get; private set; }
        public int ExpertId { get; private set; }

        public GetPredictionsByTourAndExpert(int tourId, int expertId)
        {
            TourId = tourId;
            ExpertId = expertId;
        }
    }
}
