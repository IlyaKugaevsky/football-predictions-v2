using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ReadModel.Features.Tours.Dtos;

namespace ReadModel.Features.Tournaments.Dtos
{
    public class TournamentScheduleDto
    {
        [JsonProperty(PropertyName = "tourSchedules")]
        private readonly List<TourScheduleReadDto> _tourSchedules;

        public TournamentScheduleDto(TournamentInfoReadDto tournamentInfo,
            IEnumerable<TourScheduleReadDto> tourSchedules)
        {
            TournamentInfo = tournamentInfo;
            _tourSchedules = tourSchedules.ToList();
        }

        public TournamentInfoReadDto TournamentInfo { get; private set; }

        public IReadOnlyCollection<TourScheduleReadDto> TourSchedules()
        {
            return _tourSchedules.AsReadOnly();
        }
    }
}