using System;
using System.Linq.Expressions;

namespace Predictions.Persistence.FetchStrategies
{
    public interface IFetchStrategy<T>
    {
        Expression<Func<T, object>> Apply();
    }
}
