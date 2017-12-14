// using System;
// using System.Linq.Expressions;
// using Predictions.Persistence.Entities;

// namespace Predictions.Persistence.FetchStrategies.TournamentsFetchStrategies
// {
//     public class FetchTours : IFetchStrategy<Tournament>
//     {
//         public Expression<Func<Tournament, object>> Apply()
//         {
//             return t => t.NewTours;
//         }
//     }
// }