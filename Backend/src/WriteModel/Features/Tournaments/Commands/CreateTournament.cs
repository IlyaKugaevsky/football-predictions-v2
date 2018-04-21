using System;
using MediatR;

namespace WriteModel.Features.Tournaments.Commands
{
    public class CreateTournament : IRequest<bool>
    {
        public CreateTournament (string title, DateTime startDate, DateTime endDate)
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string Title { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}