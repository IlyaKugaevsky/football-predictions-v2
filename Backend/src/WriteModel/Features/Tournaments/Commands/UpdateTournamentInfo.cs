using System;
using MediatR;

namespace WriteModel.Features.Tournaments.Commands
{
    public class UpdateTournamentInfo : IRequest<bool>
    {
        public UpdateTournamentInfo(int id, string title, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Id { get; }
        public string Title { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}