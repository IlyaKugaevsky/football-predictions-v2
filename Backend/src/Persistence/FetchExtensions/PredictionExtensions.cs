using Domain.Models;
using Persistence.QueryExtensions;
using System.Linq;

namespace Persistence.FetchExtensions
{
    public static class PredictionExtensions
    {
        public static IQueryable<Prediction> Fetch(this IQueryable<Prediction> predictions, FetchMode fetchMode)
        {
            return predictions.ApplyFetchMode(fetchMode);
        }
    }
}
