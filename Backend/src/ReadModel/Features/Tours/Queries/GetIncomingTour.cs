using System.Collections.Generic;
using MediatR;
using ReadModel.Features.Tours.Dtos;

namespace ReadModel.Features.Tours.Queries
{
    public class GetIncomingTour: IRequest<TourScheduleReadDto>
    {
    }
}
