using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Predictions.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Predictions.Persistence.QueryExtensions
{
    public static class TournamentQueryExtensions
    {
        public async static Task<Tournament> LastStartedAsync(this IQueryable<Tournament> tournaments) 
            => await tournaments.OrderByDescending(t => t.StartDate).FirstAsync();
    }
}