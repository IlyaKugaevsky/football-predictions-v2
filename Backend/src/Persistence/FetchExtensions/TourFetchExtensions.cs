using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Persistence.FetchExtensions
{
    public static class TourFetchExtensions
    {
        public static IQueryable<Tour> FetchWithMatchesAndPredictionsAndExperts(this IQueryable<Tour> tours)
        {
            return tours.Include(t => t.Matches).ThenInclude(m => m.Predictions).ThenInclude(p => p.Expert);
        }

    }
}
