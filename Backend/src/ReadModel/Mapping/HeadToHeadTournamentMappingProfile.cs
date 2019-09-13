using AutoMapper;
using Domain.Models;
using ReadModel.Features.HeadToHead.Dtos;

namespace ReadModel.Mapping
{
    public class HeadToHeadTournamentMappingProfile: Profile
    {
        public HeadToHeadTournamentMappingProfile()
        {
            CreateMap<HeadToHeadTournament, HeadToHeadTournamentReadDto>();   
        }
    }
}