using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace WriteModel.Features.Experts.Commands
{
    public class DeleteExpert : IRequest<bool>
    {
        public DeleteExpert(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }

}
