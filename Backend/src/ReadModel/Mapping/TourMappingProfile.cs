using AutoMapper;
using Domain.Models;
using ReadModel.Features.Tours.Dtos;

namespace ReadModel.Mapping
{
    public class TourMappingProfile : Profile
    {
        public TourMappingProfile()
        {
            CreateMap<Tour, TourInfoReadDto>();
        }
    }
}