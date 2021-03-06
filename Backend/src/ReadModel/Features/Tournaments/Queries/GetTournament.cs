using MediatR;
using ReadModel.Features.Tournaments.Dtos;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetTournament : IRequest<TournamentInfoReadDto>
    {
        public int TournamentId { get; }

        public GetTournament(int id)
        {
            TournamentId = id;
        }
    }
}