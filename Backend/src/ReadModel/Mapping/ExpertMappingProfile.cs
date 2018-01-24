using AutoMapper;
using Domain.Models;
using ReadModel.Features.Experts.Dtos;

namespace ReadModel.Mapping
{
    public class ExpertMappingProfile : Profile
    {
        public ExpertMappingProfile()
        {
            CreateMap<Expert, ExpertInfoReadDto>()
                .ConstructUsing(e => new ExpertInfoReadDto(e.Id, e.Nickname));
        }
    }
}