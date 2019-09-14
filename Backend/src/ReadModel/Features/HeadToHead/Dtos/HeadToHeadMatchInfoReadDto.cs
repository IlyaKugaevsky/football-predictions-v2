using ReadModel.Features.Experts.Dtos;

namespace ReadModel.Features.HeadToHead.Dtos
{
    public class HeadToHeadMatchInfoReadDto
    {
        public HeadToHeadMatchInfoReadDto(int id, int headToHeadTourId, bool isOver, HeadToHeadExpertReadDto homeExpert,
            HeadToHeadExpertReadDto awayExpert)
        {
            Id = id;
            HeadToHeadTourId = headToHeadTourId;
            IsOver = isOver;
            HomeExpert = homeExpert;
            AwayExpert = awayExpert;
        }

        public int Id { get; }
        public int HeadToHeadTourId { get; }
        public bool IsOver { get; }

        public HeadToHeadExpertReadDto HomeExpert { get; }
        public HeadToHeadExpertReadDto AwayExpert { get; }
    }
}