using AutoMapper;
using Domain.Models;
using ReadModel.Features.Tournaments.Dtos;

namespace ReadModel.Mapping
{
    public class TournamentMappingProfile : Profile
    {
        public TournamentMappingProfile()
        {
            CreateMap<Tournament, TournamentInfoReadDto>();
        }
    }
}