using AutoMapper;
using Predictions.WriteModel.Features.Tournaments.Dtos;
using Predictions.Domain.Models;

namespace Predictions.WriteModel.Mapping
{
    public class TournamentMappingProfile : Profile
    {
        public TournamentMappingProfile()
        {
            ShouldMapField = fieldInfo => true;
            ShouldMapProperty = propertyInfo => true;

            CreateMap<Tournament, TournamentInfoWriteDto>();
        }
    }
}