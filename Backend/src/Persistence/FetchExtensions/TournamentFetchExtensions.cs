using System.Linq;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.FetchExtensions
{
    public static class TournamentFetchExtensions
    {
        public static IQueryable<Tournament> FetchWithTours(this IQueryable<Tournament> tournaments)
        {
            return tournaments.Include(trn => trn.Tours);
        }

        public static IQueryable<Tournament> FetchWithToursAndMatches(this IQueryable<Tournament> tournaments)
        {
            return tournaments.Include(trn => trn.Tours).ThenInclude(tr => tr.Matches);
        }

        public static IQueryable<Tournament> FetchWithScheduleInfo(this IQueryable<Tournament> tournaments)
        {
            return tournaments
                .Include(trn => trn.Tours)
                .ThenInclude(t => t.Matches).ThenInclude(m => m.HomeTeam)
                .Include(trn => trn.Tours)
                .ThenInclude(t => t.Matches).ThenInclude(m => m.AwayTeam)
                .Include(trn => trn.Tours)
                .ThenInclude(t => t.Matches).ThenInclude(m => m.Score);
        }
    }
}