using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Tournament : Entity
    {
        private readonly List<Tour> _tours = new List<Tour>();

        protected Tournament()
        {
        }

        internal Tournament(int id, string title, DateTime startDate, DateTime endDate) 
            : this(title, startDate, endDate)
        {
            Id = id;
        }

        public Tournament(string title, DateTime startDate, DateTime endDate)
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public IEnumerable<Tour> Tours => _tours.AsReadOnly();

        public void UpdateInfo(string title, DateTime startDate, DateTime endDate)
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void AddTours(IEnumerable<Tour> tours)
        {
            _tours.AddRange(tours);
        }

        public void AddTour(Tour tour)
        {
            _tours.Add(tour);
        }

    }
}