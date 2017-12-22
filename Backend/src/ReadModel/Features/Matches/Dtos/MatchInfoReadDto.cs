using System;
using System.Collections.Generic;
using Predictions.Domain;
using Predictions.Domain.Models;

namespace Predictions.ReadModel.Features.Matches.Dtos
{
    public class MatchInfoReadDto
    {
        public string Id { get; private set; }
        public DateTime Date { get; private set; }
        public string HomeTeamTitle { get; private set; }
        public string AwayTeamTitle { get; private set; }
        public string Result { get; private set; }
    }
}