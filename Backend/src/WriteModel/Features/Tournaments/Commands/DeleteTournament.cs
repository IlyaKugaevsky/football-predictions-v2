using MediatR;

namespace WriteModel.Features.Tournaments.Commands
{
    public class DeleteTournament : IRequest<bool>
    {
        public DeleteTournament(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}