using Domain.Models;
using Persistence.QueryExtensions;
using System.Linq;

namespace Persistence.FetchExtensions
{
    public static class ExpertFetchExtensions
    {
        public static IQueryable<Expert> Fetch(this IQueryable<Expert> experts, FetchMode fetchMode)
        {
            return experts.ApplyFetchMode(fetchMode);
        }
    }
}
