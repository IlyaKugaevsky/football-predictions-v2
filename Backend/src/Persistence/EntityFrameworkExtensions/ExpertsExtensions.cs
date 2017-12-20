using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Predictions.Persistence;

namespace Predictions.Persistence.EntityFrameworkExtensions
{
    public static class ExpertsExtensions
    {
        // public static IQueryable<Expert> GetExperts(this PredictionsContext context, IFetchStrategy<Expert>[] fetchStrategies = null)
        // {
        //     if (fetchStrategies == null) return context.Experts;
        //     var appliedStrategies = fetchStrategies.Select(fs => fs.Apply()).ToArray();
        //     return context.Experts.IncludeMultiple<Expert>(appliedStrategies);
        // }
    }
}