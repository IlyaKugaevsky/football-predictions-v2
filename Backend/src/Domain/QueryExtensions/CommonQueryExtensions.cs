using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Domain.QueryExtensions
{
    public static class CommonQueryExtensions
    {
        public static T WithId<T>(this IEnumerable<T> entities, int id)
            where T : Entity
        {
            return entities.Single(e => e.Id == id);
        }
    }
}