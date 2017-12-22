using AutoMapper;
using Predictions.ReadModel.Features.Tournaments.Dtos;
using Predictions.Domain.Models;

namespace Predictions.ReadModel.Mapping
{
    public class TournamentMappingProfile : Profile
    {
        public TournamentMappingProfile()
        {
            ShouldMapField = fieldInfo => true;
            ShouldMapProperty = propertyInfo => true;

            CreateMap<Tournament, TournamentInfoReadDto>();
            // CreateMap<Match, MatchInfoDto>();
        }
    }
}