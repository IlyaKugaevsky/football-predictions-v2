using System;
using System.Collections.Generic;
using Predictions.Domain;
using Predictions.Domain.Models;

namespace Predictions.ReadModel.Features.Tours.Dtos
{
    public class TourInfoReadDto
    {
        public int Id { get; private set; }
        public int Number { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsClosed { get; private set; }
    }
}