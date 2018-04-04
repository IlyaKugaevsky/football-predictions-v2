using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.FetchExtensions;

namespace Persistence.QueryExtensions
{
    public static class CommonQueryExtensions
    {
        public static async Task<Entity> ByIdAsync(this IQueryable<Entity> entities, int id)
        {
            return await entities.SingleAsync(e => e.Id == id);
        }

        public static async Task<int> GetTourIdFromNumberAndTournamentId(this PredictionsContext context, int tourNumber, int tournamentId)
        {
            var tournament = await context.Tournaments.FetchWithTours().ByIdAsync(tournamentId) as Tournament;
            var tour = tournament.Tours.Single(t => t.Number == tourNumber);
            return tour.Id;
        }
    }
}