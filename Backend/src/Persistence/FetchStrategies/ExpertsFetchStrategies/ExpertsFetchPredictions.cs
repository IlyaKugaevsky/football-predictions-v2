using System;
using System.Linq.Expressions;
using Predictions.Persistence.Entities;

namespace Predictions.Persistence.FetchStrategies.ExpertsFetchStrategies
{
    public class ExpertsFetchPredictions: IFetchStrategy<Expert>
    {
        public Expression<Func<Expert, object>> Apply()
        {
            return e => e.Predictions;
        }
    }
}