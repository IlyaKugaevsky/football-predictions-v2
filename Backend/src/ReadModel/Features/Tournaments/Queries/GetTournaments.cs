using System.Collections.Generic;
using MediatR;
using ReadModel.Features.Tournaments.Dtos;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetTournaments : IRequest<IEnumerable<TournamentInfoReadDto>>
    {
    }
}