using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Predictions.Persistence.Entities;

namespace Predictions.Persistence
{
    public class PredictionsContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public PredictionsContext(DbContextOptions<PredictionsContext> options) : base(options) { }

        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new [] { new ConsoleLoggerProvider((_, __) => true, true) });

        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<Expert> Experts { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Prediction> Predictions { get; set; }
        public virtual DbSet<OldTour> OldTours { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)        
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
        }

        public void BeginTransaction()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = Database.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

    }
}