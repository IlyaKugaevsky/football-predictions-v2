using Microsoft.EntityFrameworkCore;
using Predictions.Persistence;

namespace Predictions.PersistenceTests.LocalDbTests.DbInitializers
{
    public interface IDbInitializer
    {
        void SeedDatabase(DbContext context);
    }
}