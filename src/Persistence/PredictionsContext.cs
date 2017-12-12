using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Predictions.Persistence.Entities;

namespace Predictions.Persistence
{
    public class PredictionsContext : DbContext
    {

        public PredictionsContext (DbContextOptions<PredictionsContext> options) : base (options) { }

        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory (new [] { new ConsoleLoggerProvider ((_, __) => true, true) });

        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<Expert> Experts { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Prediction> Predictions { get; set; }
        public virtual DbSet<OldTour> OldTours { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)        
        {
            optionsBuilder
                .UseLoggerFactory (MyLoggerFactory);
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention ();
        }
    }
}