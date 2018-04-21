using MediatR;
using ReadModel.Features.Predictions.Dtos;
using System.Collections.Generic;

namespace ReadModel.Features.Predictions.Queries
{
    public class GetPredictions: IRequest<IEnumerable<PredictionMinimalInfoReadDto>>
    {
    }
}
