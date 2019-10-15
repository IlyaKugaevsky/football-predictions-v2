using MediatR;

namespace WriteModel.Features.HeadToHead.Commands
{
    public class RollbackHeadToHeadTour: IRequest<bool>
    {
        public RollbackHeadToHeadTour(int id)
        {
            HeadToHeadTourId = id;
        }
        public int HeadToHeadTourId { get;  }
    }
}