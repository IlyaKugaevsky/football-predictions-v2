using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.FetchExtensions;

namespace Persistence.QueryExtensions
{
    public static class CommonQueryExtensions
    {
        public static async Task<T> WithIdAsync<T>(this IQueryable<T> entities, int id, CancellationToken cancellationToken)
            where T : Entity
        {
            return await entities.SingleAsync(e => e.Id == id, cancellationToken);
        }

        public static IQueryable<T> ApplyFetchMode<T>(this IQueryable<T> entities, FetchMode fetchMode)
            where T : Entity
        {
            if (fetchMode == FetchMode.ForRead)
            {
                entities = entities.AsNoTracking();
            }

            return entities;
        }
    }
}