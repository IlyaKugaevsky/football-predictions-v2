using System.Linq;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.QueryExtensions;

namespace Persistence.FetchExtensions
{
    public static class HeadToHeadFetchExtensions
    {
        public static IQueryable<HeadToHeadTournament> FetchWithTours(this IQueryable<HeadToHeadTournament> tournaments, FetchMode fetchMode)
        {
            return tournaments
                .Include(trn => trn.Tours)
                .ApplyFetchMode(fetchMode);
        }

        public static IQueryable<HeadToHeadTournament> FetchWithToursAndMatches(this IQueryable<HeadToHeadTournament> tournaments, FetchMode fetchMode)
        {
            return tournaments
                .Include(trn => trn.Tours)
                .ThenInclude(tr => tr.Matches)
                .ApplyFetchMode(fetchMode);
        }

        public static IQueryable<HeadToHeadTournament> FetchWithScheduleInfo(this IQueryable<HeadToHeadTournament> tournaments, FetchMode fetchMode)
        {
            return tournaments
                .Include(trn => trn.Tours)
                .ThenInclude(t => t.Matches)
                .ThenInclude(m => m.HomeExpert)
                .Include(trn => trn.Tours)
                .ThenInclude(t => t.Matches)
                .ThenInclude(m => m.AwayExpert)
                .Include(trn => trn.Tours)
                .ThenInclude(t => t.Matches)
                .ApplyFetchMode(fetchMode);
        }
        
        public static IQueryable<HeadToHeadTour> FetchWithEvaluationInfo(this IQueryable<HeadToHeadTour> tours, FetchMode fetchMode)
        {
            return tours
                .Include(tr => tr.Matches)
                .Include(tr => tr.ParentTour)
                .ThenInclude(ptr => ptr.Matches)
                .ThenInclude(m => m.Predictions)
                .ThenInclude(p => p.Expert)                    
                .ApplyFetchMode(fetchMode);
        }
        
        public static IQueryable<HeadToHeadMatch> FetchWithExperts(this IQueryable<HeadToHeadMatch> matches, FetchMode fetchMode)
        {
            return matches
                .Include(m => m.HomeExpert)
                .Include(m => m.AwayExpert)
                .ApplyFetchMode(fetchMode);
        }
    }
}