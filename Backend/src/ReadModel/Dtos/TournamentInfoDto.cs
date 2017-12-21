using System;
using System.Collections.Generic;
using Predictions.Domain;
using Predictions.Domain.Models;

namespace Predictions.ReadModel.Dtos
{
    public class TournamentInfoDto
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}