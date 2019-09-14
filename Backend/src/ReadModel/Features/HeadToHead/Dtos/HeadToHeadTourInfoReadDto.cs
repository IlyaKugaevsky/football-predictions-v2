namespace ReadModel.Features.HeadToHead.Dtos
{
    public class HeadToHeadTourInfoReadDto
    {
        public HeadToHeadTourInfoReadDto(int id, int headToHeadTournamentId, int parentTourId)
        {
            Id = id;
            HeadToHeadTournamentId = headToHeadTournamentId;
            ParentTourId = parentTourId;
        }
        public int Id { get; }
        public int HeadToHeadTournamentId { get; }
        public int ParentTourId { get; }
    }
}