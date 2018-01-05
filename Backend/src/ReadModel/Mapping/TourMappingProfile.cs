using AutoMapper;
using Predictions.Domain.Models;
using Predictions.Domain;
using Predictions.ReadModel.Features.Tours.Dtos;

namespace Predictions.ReadModel.Mapping
{
    public class TourMappingProfile : Profile
    {
        public TourMappingProfile()
        {
            // ShouldMapField = fieldInfo => true;
            // ShouldMapProperty = propertyInfo => true;

            CreateMap<Tour, TourInfoReadDto>();

            // CreateMap<TourInfoReadDto, Entity>()
            //     .Include<TourInfoReadDto, Tour>()
            //     .ForMember(e => e.Id, opt => opt.Ignore());

            // CreateMap<Tour, TourInfoReadDto>();
        }
    }
}