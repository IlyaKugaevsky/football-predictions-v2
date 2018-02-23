using System.Collections.Generic;
using MediatR;
using ReadModel.Features.Tours.Dtos;


namespace ReadModel.Features.Tours.Queries
{
    public class GetTournamentTours: IRequest<IEnumerable<TourInfoReadDto>>
    {
        public int TournamentId { get; private set; }

        public GetTournamentTours(int id)
        {
            TournamentId = id;
        }
    }
}
