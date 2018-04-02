using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReadModel.Features.Experts.Dtos;


namespace ReadModel.Features.Stats.Queries
{
    public class GetTourPredictionResults: IRequest<IEnumerable<ExpertTourResultsReadDto>>
    {
        public int TourId { get; private set; }

        public GetTourPredictionResults(int tourId)
        {
            TourId = tourId;
        }
    }
}
