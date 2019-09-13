using System.Data;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Persistence.Configurations;
using Persistence.Helpers;

namespace Persistence
{
    public class PredictionsContext : DbContext, IReadOnlyPredictionsContext
    {
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] {new ConsoleLoggerProvider((_, __) => true, true)});

        private IDbContextTransaction _currentTransaction;

        public PredictionsContext(DbContextOptions<PredictionsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<Expert> Experts { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Prediction> Predictions { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        public virtual DbSet<HeadToHeadTournament> HeadToHeadTournaments { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            
            modelBuilder.HasDefaultSchema("dbo");


            modelBuilder.ApplyConfiguration(new TournamentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MatchEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TourEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TeamEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PredictionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExpertEntityConfiguration());
            
            modelBuilder.ApplyConfiguration(new HeadToHeadTournamentEntityConfiguration());
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