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
        public GetPredictions()
        { }
    }
}
