using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Predictions.Domain.Models;
using Predictions.Persistence.Configurations;

namespace Predictions.Persistence
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