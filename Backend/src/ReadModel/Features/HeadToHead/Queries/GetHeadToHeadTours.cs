using System.Collections.Generic;
using MediatR;
using ReadModel.Features.HeadToHead.Dtos;

namespace ReadModel.Features.HeadToHead.Queries
{
    public class GetHeadToHeadTours : IRequest<IEnumerable<HeadToHeadTourReadDto>>
    {
    }
}