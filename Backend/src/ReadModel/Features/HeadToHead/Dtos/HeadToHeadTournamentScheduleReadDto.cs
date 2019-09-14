using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ReadModel.Features.Tournaments.Dtos;
using ReadModel.Features.Tours.Dtos;

namespace ReadModel.Features.HeadToHead.Dtos
{
    public class HeadToHeadTournamentScheduleReadDto
    {
        [JsonProperty(PropertyName = "tourSchedules")]
        private readonly List<HeadToHeadTourScheduleReadDto> _tourSchedules;

        public HeadToHeadTournamentScheduleReadDto(HeadToHeadTournamentInfoReadDto tournamentInfo,
            IEnumerable<HeadToHeadTourScheduleReadDto> tourSchedules)
        {
            TournamentInfo = tournamentInfo;
            _tourSchedules = tourSchedules.ToList();
        }

        public HeadToHeadTournamentInfoReadDto TournamentInfo { get; }

        public IReadOnlyCollection<HeadToHeadTourScheduleReadDto> TourSchedules()
        {
            return _tourSchedules.AsReadOnly();
        }
    }
}