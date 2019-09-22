using MediatR;
using ReadModel.Features.HeadToHead.Dtos;

namespace ReadModel.Features.HeadToHead.Queries
{
    public class GetHeadToHeadTable : IRequest<HeadToHeadTableReadDto>
    {
        public GetHeadToHeadTable(int headToHeadTournamentId) 
        {
            HeadToHeadTournamentId = headToHeadTournamentId;
        }
        
        public int HeadToHeadTournamentId { get;  }
    }
}