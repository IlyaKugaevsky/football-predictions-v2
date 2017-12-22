using System;
using System.Collections.Generic;
using Predictions.Domain;
using Predictions.Domain.Models;

namespace Predictions.Domain.Models
{
    public class Tournament : Entity
    {
        private readonly List<Tour> _tours = new List<Tour>();

        protected Tournament() { }
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
    }
}