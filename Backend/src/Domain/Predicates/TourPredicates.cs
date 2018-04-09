using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Predicates
{
    public static class TourPredicates
    {
        public static Expression<Func<Tour, bool>> TourNumberAndTournamentIdEquals(int tourNumber, int tournamentId)
        {
            return tour => ((tour.Number == tourNumber) && (tour.TournamentId == tournamentId));
        }
    }
}
