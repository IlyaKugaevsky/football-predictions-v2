using System.Collections.Generic;
using System.Linq;
using Domain.Models;

namespace Domain.QueryExtensions
{
    public static class TournamentQueryExtensions
    {
        public static Tournament LastStarted(this IEnumerable<Tournament> tournaments)
        {
            return tournaments.OrderByDescending(t => t.StartDate).First();
        }
    }
}