using Domain.Models;
using Persistence.QueryExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
