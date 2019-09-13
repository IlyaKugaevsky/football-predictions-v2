namespace ReadModel.Features.HeadToHead.Dtos
{
    public class HeadToHeadTournamentReadDto
    {
        public int Id { get; }
        public int ParentTournamentId { get; }

        public HeadToHeadTournamentReadDto(int id, int parentTournamentId)
        {
            Id = id;
            ParentTournamentId = parentTournamentId;
        }
    }
}