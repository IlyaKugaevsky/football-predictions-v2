using AutoMapper;
using Predictions.Domain.Models;
using Predictions.ReadModel.Features.Matches.Dtos;

namespace Predictions.ReadModel.Mapping
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            ShouldMapField = fieldInfo => true;
            ShouldMapProperty = propertyInfo => true;

            CreateMap<Match, MatchInfoDto>();
        }
    }
}