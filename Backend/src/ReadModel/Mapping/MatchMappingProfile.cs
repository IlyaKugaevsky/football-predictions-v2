using AutoMapper;
using Domain.Models;
using ReadModel.Features.Matches.Dtos;

namespace ReadModel.Mapping
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            CreateMap<Match, MatchInfoReadDto>()
                .ForMember(dest => dest.Id,
                    opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Date,
                    opts => opts.MapFrom(src => src.Date))
                .ForMember(dest => dest.HomeTeamTitle,
                    opts => opts.MapFrom(src => src.HomeTeam))
                .ForMember(dest => dest.AwayTeamTitle,
                    opts => opts.MapFrom(src => src.AwayTeam))
                .ForMember(dest => dest.Score,
                    opts => opts.MapFrom(src => src.Score));

            CreateMap<Team, string>().ConvertUsing(t => t.Title);
            CreateMap<FootballScore, string>().ConvertUsing(s => s.Value);
        }
    }
}