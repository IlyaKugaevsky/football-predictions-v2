using System;
using AutoMapper;
using Xunit;
using Shouldly;
using Predictions.Domain.Models;
using Predictions.WriteModel.Features.Tournaments.Dtos;
using Predictions.WriteModel.Mapping;

namespace Predictions.WriteModelTests
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