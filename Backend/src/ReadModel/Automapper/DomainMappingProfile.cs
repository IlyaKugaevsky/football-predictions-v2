using AutoMapper;
using Predictions.ReadModel.Dtos;
using Predictions.Domain.Models;

namespace Predictions.ReadModel.Automapper
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            ShouldMapField = fieldInfo => true;
            ShouldMapProperty = propertyInfo => true;

            CreateMap<Tournament, TournamentInfoDto>();
            // CreateMap<Match, MatchInfoDto>();
        }
    }
}