using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Predictions.Domain;
using Predictions.Domain.Models;
using Predictions.ReadModel.Features.Matches.Dtos;
using Predictions.ReadModel.Features.Tournaments.Dtos;

namespace Predictions.ReadModel.Features.Tours.Dtos
{
    public class TourScheduleDto
    {
        [JsonProperty(PropertyName = "matchInfos")]
        private readonly List<MatchInfoDto> _matchInfos = new List<MatchInfoDto>();

        public TourScheduleDto(TourInfoDto tourtInfo,
            IEnumerable<MatchInfoDto> matchInfos)
        {
            TourInfo = tourtInfo;
            _matchInfos = matchInfos.ToList();
        }

        public TourInfoDto TourInfo { get; private set; }
        public IReadOnlyCollection<MatchInfoDto> MatchInfo() 
            => _matchInfos.AsReadOnly();
    }
}