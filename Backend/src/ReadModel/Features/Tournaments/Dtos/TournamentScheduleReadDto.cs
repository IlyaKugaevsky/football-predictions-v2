using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ReadModel.Features.Tours.Dtos;

namespace ReadModel.Features.Tournaments.Dtos
{
    public class TournamentScheduleReadDto
    {
        [JsonProperty(PropertyName = "tourSchedules")]
        private readonly List<TourScheduleReadDto> _tourSchedules;

        public TournamentScheduleReadDto(TournamentInfoReadDto tournamentInfo,
            IEnumerable<TourScheduleReadDto> tourSchedules)
        {
            TournamentInfo = tournamentInfo;
            _tourSchedules = tourSchedules.ToList();
        }

        public TournamentInfoReadDto TournamentInfo { get; }

        public IReadOnlyCollection<TourScheduleReadDto> TourSchedules()
        {
            return _tourSchedules.AsReadOnly();
        }
    }
}