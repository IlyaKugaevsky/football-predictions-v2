using Predictions.Persistence;

namespace Predictions.PersistenceTests.DbInitializers
{
    public interface IDbInitializer
    {
        void SeedDatabase(PredictionsContext context);
    }
}