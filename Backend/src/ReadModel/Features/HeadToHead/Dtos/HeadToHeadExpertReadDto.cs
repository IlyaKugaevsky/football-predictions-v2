namespace ReadModel.Features.HeadToHead.Dtos
{
    public class HeadToHeadExpertReadDto
    {
        public HeadToHeadExpertReadDto(int id, string nickname, byte goals)
        {
            Id = id;
            Nickname = nickname;
            Goals = goals;
        }
        public int Id { get; }
        public string Nickname { get; }
        public byte Goals { get; }
    }
}