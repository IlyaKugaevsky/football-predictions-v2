namespace ReadModel.Features.Experts.Dtos
{
    public class ExpertInfoReadDto
    {
        public ExpertInfoReadDto(int id, string nickname)
        {
            Id = id;
            Nickname = nickname;
        }
        public int Id { get; }
        public string Nickname { get; }
    }
}