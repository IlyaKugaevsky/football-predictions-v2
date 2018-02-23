using System;
using System.Reflection;
using AutoMapper;
using Domain.Models;
using FakeItEasy;
using Microsoft.Extensions.DependencyInjection;
using ReadModel.Features.Matches.Dtos;
using ReadModel.Features.Tournaments.Dtos;
using ReadModel.Features.Tours.Dtos;
using Shouldly;
using Xunit;

namespace ReadModelTests
{
    public class MappingConfig
    {
        public MappingConfig()
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(Assembly.Load("ReadModel"));

            var provider = services.BuildServiceProvider();
            GlobalMapper = provider.GetService<IMapper>();
        }

        public IMapper GlobalMapper { get; private set; }
    }

    public class MappingTests : IClassFixture<MappingConfig>
    {
        private IMapper _mapper;
        private MappingConfig _mappingConfig;

        public MappingTests(MappingConfig mappingConfig)
        {
            _mappingConfig = mappingConfig;

            _mapper = mappingConfig.GlobalMapper;
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Fact]
        public void Should_Map_Match_To_Dto_Correctly()
        {
            var homeTeam = new Team(1, "Spartak");
            var awayTeam = new Team(2, "CSKA");

            var match = new Match(
                100500,
                1,
                homeTeam,
                awayTeam,
                DateTime.MinValue
            );

            var score = match.Score.Value;
            var matchDto = _mapper.Map<MatchInfoReadDto>(match);

            matchDto.Id.ShouldBe(match.Id);
            matchDto.Score.ShouldBe(match.Score.Value);
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

            var tourDto = _mapper.Map<TourInfoReadDto>(tour);

            tourDto.Id.ShouldBe(tour.Id);
            tourDto.Number.ShouldBe(tour.Number);
            tourDto.StartDate.ShouldBe(tour.StartDate);
            tourDto.EndDate.ShouldBe(tour.EndDate);
            tour.IsClosed.ShouldBe(tour.IsClosed);
        }

        [Fact]
        public void Should_Map_Tournament_To_Dto_Correctly()
        {
            var tournament = new Tournament(
                1,
                "TestTitle",
                DateTime.MinValue,
                DateTime.MaxValue);

            var tournamentDto = _mapper.Map<TournamentInfoReadDto>(tournament);

            tournamentDto.Id.ShouldBe(tournament.Id);
            tournamentDto.Title.ShouldBe(tournament.Title);
            tournamentDto.StartDate.ShouldBe(tournament.StartDate);
            tournamentDto.EndDate.ShouldBe(tournament.EndDate);
        }
    }
}