using Microsoft.EntityFrameworkCore;

namespace PersistenceTests.LocalDbTests.DbInitializers
{
    public interface IDbInitializer
    {
        void SeedDatabase(DbContext context);
    }
}