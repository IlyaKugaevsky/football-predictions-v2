using System.Collections.Generic;
using Newtonsoft.Json;
using ReadModel.Features.Matches.Dtos;
using ReadModel.Features.Tours.Dtos;

namespace ReadModel.Features.HeadToHead.Dtos
{
    public class HeadToHeadTourScheduleReadDto
    {
        [JsonProperty(PropertyName = "matchInfos")]
        private readonly List<HeadToHeadMatchInfoReadDto> _matchInfos = new List<HeadToHeadMatchInfoReadDto>();

        public HeadToHeadTourScheduleReadDto(HeadToHeadTourInfoReadDto tourInfo,
            IEnumerable<HeadToHeadMatchInfoReadDto> matchInfos)
        {
            TourInfo = tourInfo;
            _matchInfos.AddRange(matchInfos);
        }

        public HeadToHeadTourInfoReadDto TourInfo { get; }

        public IReadOnlyCollection<HeadToHeadMatchInfoReadDto> MatchInfo()
        {
            return _matchInfos.AsReadOnly();
        }
    }
}