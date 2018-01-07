using System.Collections.Generic;
using System.Linq;
using Predictions.Domain.Models;

namespace Predictions.Domain.QueryExtensions
{
    public static class TournamentQueryExtensions
    {
        public static Tournament LastStarted(this IEnumerable<Tournament> tournaments) 
            => tournaments.OrderByDescending(t => t.StartDate).First();
    }
}