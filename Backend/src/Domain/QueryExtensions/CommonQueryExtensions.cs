using System.Collections.Generic;
using System.Linq;

namespace Domain.QueryExtensions
{
    public static class CommonQueryExtensions
    {
        public static Entity ById(this IEnumerable<Entity> entities, int id)
        {
            return entities.Single(e => e.Id == id);
        }
    }
}