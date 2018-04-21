using System;
using System.Diagnostics.CodeAnalysis;
using Domain.Services;
using Shouldly;
using Xunit;

namespace DomainTests.ServiceTests
{
    [SuppressMessage("ReSharper", "UnusedVariable")]
    public class FootballScoreProcessorTests
    {
        [Theory]
        [InlineData("1:0")]
        [InlineData("0:1")]
        [InlineData("10:3")]
        [InlineData("1:33")]
        [InlineData("10:9")]
        public void Should_Recognize_Valid_Football_Score(string input)
        {
            FootballScoreProcessor.IsValidScoreExpr(input).ShouldBeTrue();
        }

        [Theory]
        [InlineData("111:0")]
        [InlineData("2:123")]
        [InlineData("104:334")]
        [InlineData("blablabla")]
        [InlineData("-1:-4")]
        [InlineData("")]
        public void Should_Recognize_Invalid_Football_Score(string input)
        {
            FootballScoreProcessor.IsValidScoreExpr(input).ShouldBeFalse();
        }

        [Fact]
        public void Should_Extract_HomeGoals_Correctly()
        {
            FootballScoreProcessor.ExtractHomeGoals("12:0").ShouldBe(12);
            FootballScoreProcessor.ExtractHomeGoals("1:1").ShouldBe(1);
        }

        [Fact]
        public void Should_Extract_AwayGoals_Correctly()
        {
            FootballScoreProcessor.ExtractAwayGoals("3:4").ShouldBe(4);
            FootballScoreProcessor.ExtractAwayGoals("1:10").ShouldBe(10);
        }

        [Fact]
        public void Should_Create_Score_Expression_Correctly()
        {
            FootballScoreProcessor.CreateScoreExpr(1, 2).ShouldBe("1:2");
            FootballScoreProcessor.CreateScoreExpr(11, 22).ShouldBe("11:22");
        }

        [Fact]
        public void Should_Throw_On_Invalid_Input_Expression()
        {
            Should.Throw<ArgumentException>(() => { var never = FootballScoreProcessor.ExtractHomeGoals("123:0"); });
            Should.Throw<ArgumentException>(() => { var never = FootballScoreProcessor.ExtractAwayGoals("completely invalid!"); });
            Should.Throw<ArgumentException>(() => { var never = FootballScoreProcessor.ExtractGoals("123:0"); });
        }

        [Fact]
        public void Should_Throw_On_Invalid_Goals_Number()
        {
            Should.Throw<ArgumentException>(() => { var never = FootballScoreProcessor.CreateScoreExpr(123, 9999); });
            Should.Throw<ArgumentException>(() => { var never = FootballScoreProcessor.CreateScoreExpr(-3, 1); });
            Should.Throw<ArgumentException>(() => { var never = FootballScoreProcessor.CreateScoreExpr(0, 200); });
        }

    }
}
