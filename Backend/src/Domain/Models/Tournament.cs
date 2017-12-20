using System;
using System.Collections.Generic;
using Predictions.Domain.Models;
using Predictions.Domain;


namespace Predictions.Domain.Models
{
    public class Tournament: Entity
    {
        public string Title { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public virtual List<Tour> Tours { get; set; }
    }
}