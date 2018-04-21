using System;
using System.Reflection;
using AutoMapper;
using Domain.Models;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using ReadModel.Features.Matches.Dtos;
using ReadModel.Features.Tournaments.Dtos;
using ReadModel.Features.Tours.Dtos;
using ReadModel.Features.Predictions.Dtos;
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

        public IMapper GlobalMapper { get; }
    }

    public class MappingTests : IClassFixture<MappingConfig>
    {
        private readonly IMapper _mapper;

        public MappingTests(MappingConfig mappingConfig)
        {
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

            match.SetScore(1, 2);


            var matchDto = _mapper.Map<MatchInfoReadDto>(match);

            matchDto.Id.ShouldBe(match.Id);
            matchDto.HomeTeamTitle.ShouldBe(match.HomeTeam.Title);
            matchDto.AwayTeamTitle.ShouldBe(match.AwayTeam.Title);
            FootballScoreProcessor.CreateScoreExpr(match.HomeGoals, match.AwayGoals).ShouldBe(matchDto.Score);

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

        [Fact]
        public void Should_Map_Prediction_To_Dto_Correctly()
        {
            var prediction = new Prediction(1, 2, "2:0", 1, false, false, true, true);

            var predictionDto = _mapper.Map<PredictionMinimalInfoReadDto>(prediction);

            predictionDto.Id.ShouldBe(prediction.Id);
            predictionDto.ExpertId.ShouldBe(prediction.ExpertId);
            predictionDto.Value.ShouldBe(prediction.Value);

            predictionDto.Sum.ShouldBe(prediction.Sum);

            predictionDto.Score.ShouldBe(prediction.Score);
            predictionDto.Difference.ShouldBe(prediction.Difference);
            predictionDto.Outcome.ShouldBe(prediction.Outcome);

            predictionDto.IsClosed.ShouldBe(prediction.IsClosed);
        }

        [Fact]
        public void Should_Map_Prediction_To_Full_Dto_Correctly()
        {
            // var homeTeam = new Team(1, "Spartak");
            // var awayTeam = new Team(2, "CSKA");

            // var match = new Match(
            //     100500,
            //     1,
            //     homeTeam,
            //     awayTeam,
            //     DateTime.MinValue
            // );


            // var prediction = new Prediction(1, "2:0", 1, false, false, true, true);

            // prediction.AttachMatch(match);

            // var predictionDto = _mapper.Map<PredictionFullInfoReadDto>(prediction);

            //predictionDto.Id.ShouldBe(prediction.Id);
            //predictionDto.Value.ShouldBe(prediction.Value);

            //predictionDto.Sum.ShouldBe(prediction.Sum);

            //predictionDto.Score.ShouldBe(prediction.Score);
            //predictionDto.Difference.ShouldBe(prediction.Difference);
            //predictionDto.Outcome.ShouldBe(prediction.Outcome);

            //predictionDto.IsClosed.ShouldBe(prediction.IsClosed);
        }


    }
}