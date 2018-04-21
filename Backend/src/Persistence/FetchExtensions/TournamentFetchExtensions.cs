using System.Linq;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.QueryExtensions;

namespace Persistence.FetchExtensions
{
    public static class TournamentFetchExtensions
    {
        public static IQueryable<Tournament> Fetch(this IQueryable<Tournament> tournaments, FetchMode fetchMode)
        {
            return tournaments
                .ApplyFetchMode(fetchMode);
        }

        public static IQueryable<Tournament> FetchWithTours(this IQueryable<Tournament> tournaments, FetchMode fetchMode)
        {
            return tournaments
                .Include(trn => trn.Tours)
                .ApplyFetchMode(fetchMode);
        }

        public static IQueryable<Tournament> FetchWithToursAndMatches(this IQueryable<Tournament> tournaments, FetchMode fetchMode)
        {
            return tournaments
                .Include(trn => trn.Tours)
                .ThenInclude(tr => tr.Matches)
                .ApplyFetchMode(fetchMode);
        }

        public static IQueryable<Tournament> FetchWithScheduleInfo(this IQueryable<Tournament> tournaments, FetchMode fetchMode)
        {
            return tournaments
                .Include(trn => trn.Tours)
                    .ThenInclude(t => t.Matches)
                    .ThenInclude(m => m.HomeTeam)
                .Include(trn => trn.Tours)
                    .ThenInclude(t => t.Matches)
                    .ThenInclude(m => m.AwayTeam)
                .Include(trn => trn.Tours)
                    .ThenInclude(t => t.Matches)
                .ApplyFetchMode(fetchMode);
        }
    }
}