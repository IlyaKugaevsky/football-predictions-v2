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
    public class TournamentScheduleDto
    {
        [JsonProperty(PropertyName = "tourSchedules")]
        private readonly List<TourScheduleDto> _tourSchedules;
    
        public TournamentScheduleDto(TournamentInfoDto tournamentInfo,
            IEnumerable<TourScheduleDto> tourSchedules)
        {
            TournamentInfo = tournamentInfo;
            _tourSchedules = tourSchedules.ToList();
        }

        public TournamentInfoDto TournamentInfo { get; private set; }
        public IReadOnlyCollection<TourScheduleDto> TourSchedules() 
            => _tourSchedules.AsReadOnly();
    }
}