using AutoMapper;
using Predictions.Domain;
using Predictions.Domain.Models;
using Predictions.WriteModel.Features.Tournaments.Dtos;

namespace Predictions.WriteModel.Mapping
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