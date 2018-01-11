using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.QueryExtensions
{
    public static class TournamentQueryExtensions
    {
        public static async Task<Tournament> LastStartedAsync(this IQueryable<Tournament> tournaments)
        {
            return await tournaments.OrderByDescending(t => t.StartDate).FirstAsync();
        }
    }
}