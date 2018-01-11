using AutoMapper;
using Domain;
using Domain.Models;
using WriteModel.Features.Tournaments.Dtos;

namespace WriteModel.Mapping
{
    public class TournamentMappingProfile : Profile
    {
        public TournamentMappingProfile()
        {
            CreateMap<TournamentInfoWriteDto, Entity>()
                .Include<TournamentInfoWriteDto, Tournament>()
                .ForMember(e => e.Id, opt => opt.Ignore());

            CreateMap<TournamentInfoWriteDto, Tournament>();
        }
    }
}