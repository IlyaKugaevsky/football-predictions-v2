using System.Collections.Generic;
using System.Linq;
using Domain.Models;

namespace Domain.QueryExtensions
{
    public static class MatchQueryExtensions
    {
        public static IEnumerable<Prediction> GetPredictionsForExpert(this IEnumerable<Match> matches, int expertId)
        {
            return matches.SelectMany(m => m.Predictions).Where(p => p.ExpertId == expertId);
        }
    }
}
