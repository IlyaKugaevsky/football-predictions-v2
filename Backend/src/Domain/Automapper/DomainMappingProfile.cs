using AutoMapper;
using Predictions.Domain.Dtos;
using Predictions.Domain.Models;

namespace Predictions.Domain.Automapper
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            ShouldMapField = fieldInfo => true;
            ShouldMapProperty = propertyInfo => true;

            CreateMap<Tournament, TournamentInfoDto>();
            CreateMap<Match, MatchInfoDto>();
        }
    }
}