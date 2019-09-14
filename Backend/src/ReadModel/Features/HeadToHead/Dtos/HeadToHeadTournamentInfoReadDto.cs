namespace ReadModel.Features.HeadToHead.Dtos
{
    public class HeadToHeadTournamentInfoReadDto
    {
        public int Id { get; }
        public int ParentTournamentId { get; }

        public HeadToHeadTournamentInfoReadDto(int id, int parentTournamentId)
        {
            Id = id;
            ParentTournamentId = parentTournamentId;
        }
    }
}