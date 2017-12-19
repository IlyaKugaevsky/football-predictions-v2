using System.Linq;
using Microsoft.EntityFrameworkCore;
using Predictions.Persistence.Entities;

namespace Predictions.Persistence.EntityFrameworkExtensions
{
    public static class MatchesExtensions
    {
        // public static IQueryable<Match> GetMatches(this PredictionsContext context, IFetchStrategy<Match>[] fetchStrategies)
        // {
        //     var appliedStrategies = fetchStrategies.Select(fs => fs.Apply()).ToArray();
        //     return context.Matches.IncludeMultiple<Match>(appliedStrategies);
        // }
    }
}