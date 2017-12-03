using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Predictions.Persistence.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Predictions.Persistence
{
    public class PredictionsContext : DbContext
    {
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<Expert> Expert { get; set; }
        public virtual DbSet<Team> Teams { get; set;  }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Prediction> Predictions { get; set; }
        public virtual DbSet<OldTour> OldTours { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] {new ConsoleLoggerProvider((_, __) => true, true)});

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=predictions.c3tex0vbzbpa.us-east-2.rds.amazonaws.com; Database=predictions; User Id=cherocky; Password=cuils1990;");
            optionsBuilder
                .UseSqlServer("workstation id=Predictions.mssql.somee.com;            packet size=4096;            user id=cherocky_SQLLogin_1;            pwd=fg6ejtwfks;            data source=Predictions.mssql.somee.com;            persist security info=False;            initial catalog=Predictions")
                .UseLoggerFactory(MyLoggerFactory);
        }


        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        // }
    }
}