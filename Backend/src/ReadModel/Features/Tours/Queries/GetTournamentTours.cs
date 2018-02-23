using System.Collections.Generic;
using MediatR;
using ReadModel.Features.Tours.Dtos;


namespace ReadModel.Features.Tours.Queries
{
    class GetTournamentTours: IRequest<IEnumerable<TourInfoReadDto>>
    {
    }
}
