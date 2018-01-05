using AutoMapper;
using Predictions.Domain.Models;
using Predictions.ReadModel.Features.Matches.Dtos;

namespace Predictions.ReadModel.Mapping
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            CreateMap<Match, MatchInfoReadDto>()
                .ForMember(dto => dto.Score, opt => opt.MapFrom(m => m.Score.ScoreValue));
        }
    }
}