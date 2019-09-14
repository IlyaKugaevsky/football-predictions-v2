using AutoMapper;
using Domain.Models;
using ReadModel.Features.HeadToHead.Dtos;

namespace ReadModel.Mapping
{
    public class HeadToHeadMappingProfile: Profile
    {
        public HeadToHeadMappingProfile()
        {
            CreateMap<HeadToHeadTournament, HeadToHeadTournamentReadDto>();

            CreateMap<HeadToHeadMatch, HeadToHeadMatchReadDto>()
                .ConstructUsing(m => new HeadToHeadMatchReadDto(
                    m.Id,
                    m.HeadToHeadTourId,
                    m.IsOver,
                    new HeadToHeadExpertReadDto(m.HomeExpert.Id, m.HomeExpert.Nickname, m.HomeGoals),
                    new HeadToHeadExpertReadDto(m.AwayExpert.Id, m.AwayExpert.Nickname, m.AwayGoals)
                ));
        }
    }
}