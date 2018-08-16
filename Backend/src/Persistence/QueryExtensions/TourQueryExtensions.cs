using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Predicates;
using Domain.QueryExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence.FetchExtensions;

namespace Persistence.QueryExtensions
{
    public static class TourQueryExtensions
    {
        public static async Task<Tour> ByNumberAndTournamentIdAsync(this IQueryable<Tour> tours, int tourNumber, int tournamentId)
        {
            var predicate = TourPredicates.TourNumberAndTournamentIdEquals(tourNumber, tournamentId);
            return await tours.SingleAsync(predicate);
        }

        public static async Task<Tour> LastStartedAsync(this IQueryable<Tour> tours, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await tours
                .OrderByDescending(t => t.StartDate)
                .FirstAsync(cancellationToken);
        }

        public static async Task<int> GetTourId(this PredictionsContext context, int tourNumber, int tournamentId, CancellationToken cancellationToken)
        {
            var tournament = await context
                .Tournaments
                .FetchWithTours(FetchMode.ForRead)
                .WithIdAsync(tournamentId, cancellationToken);

            var tour = tournament
                .Tours
                .WithNumber(tourNumber);

            return tour.Id;
        }
    }
}
