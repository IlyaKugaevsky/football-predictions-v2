using System.Collections.Generic;
using Newtonsoft.Json;
using ReadModel.Features.Matches.Dtos;

namespace ReadModel.Features.Tours.Dtos
{
    public class TourScheduleReadDto
    {
        [JsonProperty(PropertyName = "matchInfos")]
        private readonly List<MatchInfoReadDto> _matchInfos = new List<MatchInfoReadDto>();

        public TourScheduleReadDto(TourInfoReadDto tourtInfo,
            IEnumerable<MatchInfoReadDto> matchInfos)
        {
            TourInfo = tourtInfo;
            _matchInfos.AddRange(matchInfos);
        }

        public TourInfoReadDto TourInfo { get; private set; }

        public IReadOnlyCollection<MatchInfoReadDto> MatchInfo()
        {
            return _matchInfos.AsReadOnly();
        }
    }
}