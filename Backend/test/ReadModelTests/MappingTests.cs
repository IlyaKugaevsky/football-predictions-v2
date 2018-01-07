using System;
using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Predictions.Domain.Models;
using Predictions.ReadModel.Features.Tournaments.Dtos;
using Predictions.ReadModel.Features.Tours.Dtos;
using Predictions.ReadModel.Features.Matches.Dtos;
using Predictions.ReadModel.Mapping;
using Shouldly;
using Xunit;

namespace Predictions.ReadModelTests
{
    public class MappingTests
    {
        public MappingTests()
        {
            var services = new ServiceCollection();

            AutoMapper.Mapper.Reset();
            services.AddAutoMapper(Assembly.Load("ReadModel"));
            Mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void Should_Map_Tournament_To_Dto_Correctly()
        {
            var tournament = new Tournament(
                1,
                "TestTitle",
                DateTime.MinValue,
                DateTime.MaxValue);

            var tournamentDto = Mapper.Map<TournamentInfoReadDto>(tournament);

            tournamentDto.Id.ShouldBe(tournament.Id);
            tournamentDto.Title.ShouldBe(tournament.Title);
            tournamentDto.StartDate.ShouldBe(tournament.StartDate);
            tournamentDto.EndDate.ShouldBe(tournament.EndDate);
        }

        [Fact]
        public void Should_Map_Tour_To_Dto_Correctly()
        {
            var tour = new Tour(
                1,
                2,
                DateTime.MaxValue,
                DateTime.MaxValue
            );

            var tourDto = Mapper.Map<TourInfoReadDto>(tour);

            tourDto.Id.ShouldBe(tour.Id);
            tourDto.Number.ShouldBe(tour.Number);
            tourDto.StartDate.ShouldBe(tour.StartDate);
            tourDto.EndDate.ShouldBe(tour.EndDate);
            tour.IsClosed.ShouldBe(tour.IsClosed);
        }

        [Fact]
        public void Should_Map_Match_To_Dto_Correctly()
        {
            var match = new Match(
                1,
                2,
                3,
                4,
                DateTime.MinValue
            );

            var matchDto = Mapper.Map<MatchInfoReadDto>(match);

            matchDto.Id.ShouldBe(match.Id);
            matchDto.Score.ShouldBe(match.Score.Value);
        }
    }
}