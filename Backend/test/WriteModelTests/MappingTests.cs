using System;
using AutoMapper;
using Domain.Models;
using Shouldly;
using WriteModel.Features.Tournaments.Dtos;
using WriteModel.Mapping;
using Xunit;

namespace WriteModelTests
{
    public class MappingTests
    {
        public MappingTests()
        {
            Mapper.Initialize(m => m.AddProfile<TournamentMappingProfile>());
            Mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void Should_Map_Tournament_To_Dto_Correctly()
        {
            var tournamentInfo = new TournamentInfoWriteDto(
                "TestTitle",
                DateTime.MinValue,
                DateTime.MaxValue);

            var tournament = Mapper.Map<Tournament>(tournamentInfo);

            tournament.Id.ShouldBe(default(int));
            tournament.Title.ShouldBe(tournamentInfo.Title);
            tournament.StartDate.ShouldBe(tournamentInfo.StartDate);
            tournament.EndDate.ShouldBe(tournamentInfo.EndDate);
            tournament.Tours.ShouldBeEmpty();
        }
    }
}