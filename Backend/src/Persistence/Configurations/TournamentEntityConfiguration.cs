using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Predictions.Domain.Models;

namespace Predictions.Persistence.Configurations
{
    public class TournamentEntityConfiguration: IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> tournamentConfiguration)
        {
            tournamentConfiguration.HasKey(trn => trn.Id);

            tournamentConfiguration.Property(trn => trn.Id).HasColumnName("TournamentId");

            // tournamentConfiguration.Property(t => t.Tours).HasColumnName("NewTours");

            tournamentConfiguration.Property(trn => trn.StartDate).HasColumnType("DateTime2");
            tournamentConfiguration.Property(trn => trn.EndDate).HasColumnType("DateTime2");
        }
    }
}