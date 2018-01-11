using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public interface IReadOnlyPredictionsContext
    {
        DbSet<Tournament> Tournaments { get; }
        DbSet<Expert> Experts { get; }
        DbSet<Team> Teams { get; }
        DbSet<Match> Matches { get; }
        DbSet<Prediction> Predictions { get; }
        DbSet<Tour> Tours { get; }
    }
}