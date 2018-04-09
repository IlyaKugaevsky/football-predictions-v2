using MediatR;
using ReadModel.Features.Predictions.Dtos;
using ReadModel.Features.Stats.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadModel.Features.Predictions.Queries
{
    public class GetPredictions: IRequest<IEnumerable<PredictionMinimalInfoReadDto>>
    {
        //public int TourId { get; private set; }
        //public int ExpertId { get; private set; }

        //public GetPredictions(int tourId, int expertId)
        //{
        //    //TourId = tourId;
        //    //ExpertId = expertId;
        //}

        public GetPredictions()
        { }
    }
}
