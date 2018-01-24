using System.Collections.Generic;
using MediatR;
using ReadModel.Features.Experts.Dtos;

namespace ReadModel.Features.Experts.Queries
{
    public class GetExperts: IRequest<IEnumerable<ExpertInfoReadDto>>
    { }
}