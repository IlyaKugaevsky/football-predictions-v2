using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Predictions.Domain.Models;
using Predictions.Domain.QueryExtensions;
using Predictions.Persistence;
using Predictions.Persistence.FetchExtensions;
using Predictions.Persistence.QueryExtensions;
using Shouldly;
using Xunit;

namespace Predictions.PersistenceTests.RealDbTests
{
    public class RealDbFetchingTests
    {
        IReadOnlyPredictionsContext _context;
        public RealDbFetchingTests()
        {
            var connectionString = "workstation id=Predictions.mssql.somee.com;packet size=4096;user id=cherocky_SQLLogin_1;pwd=fg6ejtwfks;data source=Predictions.mssql.somee.com;persist security info=False;initial catalog=Predictions";

            var options = new DbContextOptionsBuilder<PredictionsContext>()
                .UseSqlServer(connectionString)
                .Options;

            _context = new PredictionsContext(options);
        }

        [Fact]
        public void Should_Fetch_All_Entity_Types_Without_Errors()
        {
            Should.NotThrow(() =>
            {
                var tournaments = _context.Tournaments.AsNoTracking().Take(2);
                var tours = _context.Tours.AsNoTracking().Take(2);
                var matches = _context.Matches.AsNoTracking().Take(2);
                var predictions = _context.Predictions.AsNoTracking().Take(2);
                var experts = _context.Experts.AsNoTracking().Take(2);
                var teams = _context.Teams.AsNoTracking().Take(2);
            });
        }

        [Fact]
        public async Task Should_Fetch_Matches_With_Score_Values()
        {
            var matches = await _context.Matches.AsNoTracking().Take(2).ToListAsync();

            matches.ShouldAllBe(m => m.Score != null);
        }

        [Fact]
        public async Task Should_Fetch_Schedule_Correctly()
        {
            var schedule =  await _context.Tournaments
                            .FetchWithScheduleInfo()
                            .AsNoTracking()
                            .LastStartedAsync();

            schedule.Tours.First().Matches.ShouldAllBe(m => m.Score.Value != null);
        }
    }
}