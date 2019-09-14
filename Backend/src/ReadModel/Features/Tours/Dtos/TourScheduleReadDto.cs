using System.Collections.Generic;
using Newtonsoft.Json;
using ReadModel.Features.Matches.Dtos;

namespace ReadModel.Features.Tours.Dtos
{
    public class TourScheduleReadDto
    {
        [JsonProperty(PropertyName = "matchInfos")]
        private readonly List<MatchInfoReadDto> _matchInfos = new List<MatchInfoReadDto>();

        public TourScheduleReadDto(TourInfoReadDto tourInfo,
            IEnumerable<MatchInfoReadDto> matchInfos)
        {
            TourInfo = tourInfo;
            _matchInfos.AddRange(matchInfos);
        }

        public TourInfoReadDto TourInfo { get; }

        public IReadOnlyCollection<MatchInfoReadDto> MatchInfo()
        {
            return _matchInfos.AsReadOnly();
        }
    }
}