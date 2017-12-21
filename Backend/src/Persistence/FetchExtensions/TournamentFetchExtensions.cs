using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Predictions.Persistence;

using Predictions.Domain.Models;

namespace Predictions.Persistence.FetchExtensions
{
    public static class TournamentFetchExtensions
    {
        public static IQueryable<Tournament> FetchWithTours(this IQueryable<Tournament> tournaments)
            => tournaments.Include(trn => trn.Tours);

        public static IQueryable<Tournament> FetchWithToursAndMatches(this IQueryable<Tournament> tournaments)
            => tournaments.Include(trn => trn.Tours).ThenInclude(tr => tr.Matches);

        public static IQueryable<Tournament> FetchWithScheduleInfo(this IQueryable<Tournament> tournaments)
            => tournaments
                    .Include(trn => trn.Tours)
                    .ThenInclude(t => t.Matches).ThenInclude(m => m.HomeTeam)
                    .Include(trn => trn.Tours)
                    .ThenInclude(t => t.Matches).ThenInclude(m => m.AwayTeam);
    }
}