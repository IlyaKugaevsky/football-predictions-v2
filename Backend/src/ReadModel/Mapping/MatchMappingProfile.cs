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
                .ConstructUsing(m => new MatchInfoReadDto(m.Id, m.Date, m.HomeTeam.Title, m.AwayTeam.Title, m.Score.Value));
        }
    }
}