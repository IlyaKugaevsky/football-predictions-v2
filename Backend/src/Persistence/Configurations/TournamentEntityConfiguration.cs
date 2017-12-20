using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Predictions.Domain.Models;

namespace Predictions.Persistence.Configurations
{
    public class TournamentEntityConfiguration: IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> tournamentConfiguration)
        {
            tournamentConfiguration.HasKey(t => t.Id);

            tournamentConfiguration.Property(t => t.Id).HasColumnName("TournamentId");

            // tournamentConfiguration.Property(t => t.Tours).HasColumnName("NewTours");

            tournamentConfiguration.Property(t => t.StartDate).HasColumnType("DateTime2");
            tournamentConfiguration.Property(t => t.EndDate).HasColumnType("DateTime2");
        }
    }
}