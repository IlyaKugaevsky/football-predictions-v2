using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.QueryExtensions
{
    public static class TourQueryExtensions
    {
        public static async Task<Tour> ByNumberAndTournamentIdAsync(this IQueryable<Tour> tours, int tourNumber, int tournamentId)
        {
            return await tours.SingleAsync(t => (t.Number == tourNumber) && (t.TournamentId == tournamentId));
        }
    }
}
