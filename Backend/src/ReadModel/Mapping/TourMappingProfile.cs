using AutoMapper;
using Predictions.ReadModel.Features.Tours.Dtos;
using Predictions.Domain.Models;

namespace Predictions.ReadModel.Mapping
{
    public class TourMappingProfile : Profile
    {
        public TourMappingProfile()
        {
            ShouldMapField = fieldInfo => true;
            ShouldMapProperty = propertyInfo => true;

            CreateMap<Tour, TourInfoDto>();
        }
    }
}