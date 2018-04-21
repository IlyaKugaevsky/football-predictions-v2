using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shouldly;
using Xunit;

namespace PersistenceTests.RealDbTests
{
    [SuppressMessage("ReSharper", "UnusedVariable")]
    public class RealDbFetchingTests
    {
        public RealDbFetchingTests()
        {
            var connectionString =
                "workstation id=Predictions.mssql.somee.com;packet size=4096;user id=cherocky_SQLLogin_1;pwd=fg6ejtwfks;data source=Predictions.mssql.somee.com;persist security info=False;initial catalog=Predictions";

            var options = new DbContextOptionsBuilder<PredictionsContext>()
                .UseSqlServer(connectionString)
                .Options;

            _context = new PredictionsContext(options);
        }

        private readonly IReadOnlyPredictionsContext _context;

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
    }
}