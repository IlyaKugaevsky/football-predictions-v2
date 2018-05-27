using System;
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
            switch (fetchMode)
            {
                case FetchMode.ForRead:
                    return entities.AsNoTracking();
                case FetchMode.ForModify:
                    return entities;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fetchMode), fetchMode, "FetchMode must be either ForRead or ForModify");
            }
        }
    }
}