using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Predictions.Domain;
using Microsoft.EntityFrameworkCore;

namespace Predictions.Persistence.QueryExtensions
{
    public static class CommonQueryExtensions
    {
        public static async Task<Entity> ByIdAsync(this IQueryable<Entity> entities, int id) 
            => await entities.SingleAsync(e => e.Id == id);
    }
}