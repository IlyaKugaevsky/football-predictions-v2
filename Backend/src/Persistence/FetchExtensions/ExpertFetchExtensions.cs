using Domain.Models;
using Persistence.QueryExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
