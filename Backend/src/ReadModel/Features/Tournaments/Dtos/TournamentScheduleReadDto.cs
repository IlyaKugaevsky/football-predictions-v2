using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Predictions.Domain;
using Predictions.Domain.Models;
using Predictions.ReadModel.Features.Tournaments.Dtos;
using Predictions.ReadModel.Features.Tours.Dtos;

namespace Predictions.ReadModel.Features.Tournaments.Dtos
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

        public TournamentInfoReadDto TournamentInfo { get; private set; }
        public IReadOnlyCollection<TourScheduleReadDto> TourSchedules() 
            => _tourSchedules.AsReadOnly();
    }
}