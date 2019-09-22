using System.ComponentModel.Design.Serialization;
using Domain.Models;
using Domain.PointSystems;
using Shouldly;
using Xunit;

namespace DomainTests.ModelTests
{
    public class LeagueTableProcessorTests
    {
        private readonly ISportPointSystem _pointSystem;
        public LeagueTableProcessorTests()
        {
            _pointSystem = new FootballPointSystem();
        }

        [Fact]
        public void Should_Add_Home_Win_Correctly()
        {
            var processor = new LeagueTableProcessor("DummyTournament");

            const string homeTeamTitle = "Home";
            const string awayTeamTitle = "Away";

            const string irrelevantTeamTitle = "Irrelevant";

            const int homeTeamGoals = 1;
            const int awayTeamGoals = 0;

            var winPoints = _pointSystem.WinWeight;
            var losePoints = _pointSystem.LoseWeight;
            
            
            processor.HandleMatch(homeTeamTitle, homeTeamGoals, awayTeamTitle, awayTeamGoals);
            var table = processor.Table;

            var containsIrrelevant = table.ContainsKey(irrelevantTeamTitle);
            var homeStats = table[homeTeamTitle];
            var awayStats = table[awayTeamTitle];
            
            
            containsIrrelevant.ShouldBeFalse();
            
            homeStats.Games.ShouldBe(1);
            homeStats.Wins.ShouldBe(1);
            homeStats.Draws.ShouldBe(0);
            homeStats.Loses.ShouldBe(0);
            homeStats.ScoredGoals.ShouldBe(homeTeamGoals);
            homeStats.ConcededGoals.ShouldBe(awayTeamGoals);
            homeStats.Points.ShouldBe(winPoints);
            
            awayStats.Games.ShouldBe(1);
            awayStats.Wins.ShouldBe(0);
            awayStats.Draws.ShouldBe(0);
            awayStats.Loses.ShouldBe(1);
            awayStats.ScoredGoals.ShouldBe(awayTeamGoals);
            awayStats.ConcededGoals.ShouldBe(homeTeamGoals);
            awayStats.Points.ShouldBe(losePoints);
        }
        
        [Fact]
        public void Should_Add_Away_Win_Correctly()
        {
            var processor = new LeagueTableProcessor("DummyTournament");

            const string homeTeamTitle = "Home";
            const string awayTeamTitle = "Away";

            const string irrelevantTeamTitle = "Irrelevant";

            const int homeTeamGoals = 0;
            const int awayTeamGoals = 2;

            var winPoints = _pointSystem.WinWeight;
            var losePoints = _pointSystem.LoseWeight;
            
            
            processor.HandleMatch(homeTeamTitle, homeTeamGoals, awayTeamTitle, awayTeamGoals);
            var table = processor.Table;

            var containsIrrelevant = table.ContainsKey(irrelevantTeamTitle);
            var homeStats = table[homeTeamTitle];
            var awayStats = table[awayTeamTitle];
            
            
            containsIrrelevant.ShouldBeFalse();
            
            homeStats.Games.ShouldBe(1);
            homeStats.Wins.ShouldBe(0);
            homeStats.Draws.ShouldBe(0);
            homeStats.Loses.ShouldBe(1);
            homeStats.ScoredGoals.ShouldBe(homeTeamGoals);
            homeStats.ConcededGoals.ShouldBe(awayTeamGoals);
            homeStats.Points.ShouldBe(losePoints);
            
            awayStats.Games.ShouldBe(1);
            awayStats.Wins.ShouldBe(1);
            awayStats.Draws.ShouldBe(0);
            awayStats.Loses.ShouldBe(0);
            awayStats.ScoredGoals.ShouldBe(awayTeamGoals);
            awayStats.ConcededGoals.ShouldBe(homeTeamGoals);
            awayStats.Points.ShouldBe(winPoints);
        }
        
        [Fact]
        public void Should_Add_Draw_Correctly()
        {
            var processor = new LeagueTableProcessor("DummyTournament");

            const string homeTeamTitle = "Home";
            const string awayTeamTitle = "Away";

            const string irrelevantTeamTitle = "Irrelevant";

            const int homeTeamGoals = 1;
            const int awayTeamGoals = 1;

            var drawPoints = _pointSystem.DrawWeight;
            
            
            processor.HandleMatch(homeTeamTitle, homeTeamGoals, awayTeamTitle, awayTeamGoals);
            var table = processor.Table;

            var containsIrrelevant = table.ContainsKey(irrelevantTeamTitle);
            var homeStats = table[homeTeamTitle];
            var awayStats = table[awayTeamTitle];
            
            
            containsIrrelevant.ShouldBeFalse();
            
            homeStats.Games.ShouldBe(1);
            homeStats.Wins.ShouldBe(0);
            homeStats.Draws.ShouldBe(1);
            homeStats.Loses.ShouldBe(0);
            homeStats.ScoredGoals.ShouldBe(homeTeamGoals);
            homeStats.ConcededGoals.ShouldBe(awayTeamGoals);
            homeStats.Points.ShouldBe(drawPoints);
            
            awayStats.Games.ShouldBe(1);
            awayStats.Wins.ShouldBe(0);
            awayStats.Draws.ShouldBe(1);
            awayStats.Loses.ShouldBe(0);
            awayStats.ScoredGoals.ShouldBe(awayTeamGoals);
            awayStats.ConcededGoals.ShouldBe(homeTeamGoals);
            awayStats.Points.ShouldBe(drawPoints);
        }
    }
}