using MediatR;
using ReadModel.Features.Predictions.Dtos;

namespace ReadModel.Features.Predictions.Queries
{
    public class GetPredictionsByTourAndExpert : IRequest<ExpertTourPredictionsReadDto>
    {
        public int TourId { get; }
        public int ExpertId { get; }

        public GetPredictionsByTourAndExpert(int tourId, int expertId)
        {
            TourId = tourId;
            ExpertId = expertId;
        }
    }
}
