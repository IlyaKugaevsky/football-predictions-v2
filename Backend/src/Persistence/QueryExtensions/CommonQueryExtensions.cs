using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.QueryExtensions
{
    public static class CommonQueryExtensions
    {
        public static async Task<Entity> ByIdAsync(this IQueryable<Entity> entities, int id)
        {
            return await entities.SingleAsync(e => e.Id == id);
        }
    }
}