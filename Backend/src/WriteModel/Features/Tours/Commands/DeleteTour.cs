using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace WriteModel.Features.Tours.Commands
{
    public class DeleteTour : IRequest<bool>
    {
        public DeleteTour(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
