namespace ReadModel.Features.HeadToHead.Dtos
{
    public class HeadToHeadTourInfoReadDto
    {
        public HeadToHeadTourInfoReadDto(int id, int headToHeadTournamentId, int parentTourId, bool isOver)
        {
            Id = id;
            HeadToHeadTournamentId = headToHeadTournamentId;
            ParentTourId = parentTourId;
            IsOver = isOver;
        }
        public int Id { get; }
        public int HeadToHeadTournamentId { get; }
        public int ParentTourId { get; }
        public bool IsOver { get; }
    }
}