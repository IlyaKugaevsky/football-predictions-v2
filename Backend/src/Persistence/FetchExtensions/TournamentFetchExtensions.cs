using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Predictions.Persistence;
// using Predictions.Persistence.Entities;
using Predictions.Domain.Models;

namespace Predictions.Persistence.FetchExtensions
{
    public static class TournamentFetchExtensions
    {
        public static IQueryable<Tournament> WithTours(this IQueryable<Tournament> tournaments)
        {
            return tournaments.Include(trn => trn.Tours);
        }

        public static IQueryable<Tournament> WithToursAndMatches(this IQueryable<Tournament> tournaments)
        {
            return tournaments.Include(trn => trn.Tours).ThenInclude(tr => tr.Matches);
        }

        public static IQueryable<Tournament> WithScheduleInfo(this IQueryable<Tournament> tournaments)
        {
            return tournaments
                .Include(trn => trn.Tours)
                .ThenInclude(t => t.Matches).ThenInclude(m => m.HomeTeam)
                .Include(trn => trn.Tours)
                .ThenInclude(t => t.Matches).ThenInclude(m => m.AwayTeam);
        }
    }
}