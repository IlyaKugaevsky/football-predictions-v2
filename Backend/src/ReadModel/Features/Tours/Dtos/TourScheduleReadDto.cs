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
    public class TourScheduleReadDto
    {
        [JsonProperty(PropertyName = "matchInfos")]
        private readonly List<MatchInfoReadDto> _matchInfos = new List<MatchInfoReadDto>();

        public TourScheduleReadDto(TourInfoReadDto tourtInfo,
            IEnumerable<MatchInfoReadDto> matchInfos)
        {
            TourInfo = tourtInfo;
            _matchInfos = matchInfos.ToList();
        }

        public TourInfoReadDto TourInfo { get; private set; }
        public IReadOnlyCollection<MatchInfoReadDto> MatchInfo() 
            => _matchInfos.AsReadOnly();
    }
}