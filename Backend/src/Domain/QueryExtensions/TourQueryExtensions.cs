using System.Collections.Generic;
using System.Linq;
using Domain.Models;

namespace Domain.QueryExtensions
{
    public static class TourQueryExtensions
    {
        public static Tour WithNumber(this IEnumerable<Tour> tours, int tourNumber)
        {
            return tours.Single(t => t.Number == tourNumber);
        }
    }
}