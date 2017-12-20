using System;
using System.Collections.Generic;
using Predictions.Domain;
using Predictions.Domain.Models;
using Predictions.Domain.Dtos;

namespace Domain.Dtos
{
    public class TournamentScheduleDto
    {
        private readonly List<MatchInfoDto> _matchInfos = new List<MatchInfoDto>();
        
        public TournamentInfoDto TournamentInfo { get; private set; }
        public IReadOnlyCollection<MatchInfoDto> MatchInfo() => _matchInfos.AsReadOnly();
    }
}