using MediatR;

namespace WriteModel.Features.HeadToHead.Commands
{
    public class EvaluateHeadToHeadTour: IRequest<bool>
    {
        public EvaluateHeadToHeadTour(int id)
        {
            HeadToHeadTourId = id;
        }
        public int HeadToHeadTourId { get;  }
    }
}