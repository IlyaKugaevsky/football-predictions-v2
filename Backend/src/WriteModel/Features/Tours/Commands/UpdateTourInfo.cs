using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace WriteModel.Features.Tours.Commands
{
    public class UpdateTourInfo : IRequest<bool>
    {
        public UpdateTourInfo(int id, int number, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Number = number;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Id { get; }
        public int Number { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}
