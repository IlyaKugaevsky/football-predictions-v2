using AutoMapper;
using Domain.Models;
using Domain.Services;
using ReadModel.Features.Matches.Dtos;

namespace ReadModel.Mapping
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            CreateMap<Match, MatchInfoReadDto>()
                .ConstructUsing(m => new MatchInfoReadDto(
                    m.Id, 
                    m.Date, 
                    m.HomeTeam.Title, 
                    m.AwayTeam.Title,
                    FootballScoreProcessor.CreateScoreExpr(m.HomeGoals, m.AwayGoals)));

            CreateMap<Team, string>().ConvertUsing(t => t.Title);
        }
    }
}