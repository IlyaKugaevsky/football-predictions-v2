using System.Collections.Generic;
using System.Linq;
using Predictions.Domain;

namespace Predictions.Domain.QueryExtensions
{
    public static class CommonQueryExtensions
    {
        public static Entity LastStarted(this IEnumerable<Entity> entities, int id) 
            => entities.Single(e => e.Id == id);
    }
}