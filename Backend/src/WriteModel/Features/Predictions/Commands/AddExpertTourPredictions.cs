using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using WriteModel.Features.Predictions.Dtos;

namespace WriteModel.Features.Predictions.Commands
{
    public class AddExpertTourPredictions: IRequest<bool>
    {
        public AddExpertTourPredictions(int expertId, int tourId, IEnumerable<PredictionWriteDto> predictions)
        {
            ExpertId = expertId;
            TourId = tourId;
            Predictions = predictions;
        }

        public int ExpertId { get; }
        public int TourId { get; }

        public IEnumerable<PredictionWriteDto> Predictions { get; }
    }
}
