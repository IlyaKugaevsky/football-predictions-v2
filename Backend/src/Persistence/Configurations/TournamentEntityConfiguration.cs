using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Predictions.Domain.Models;

namespace Predictions.Persistence.Configurations
{
    public class TournamentEntityConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> tournamentConfiguration)
        {
            tournamentConfiguration.HasKey(trn => trn.Id);

            tournamentConfiguration.Property(trn => trn.Id).HasColumnName("TournamentId");

            var navigation 
                = tournamentConfiguration.Metadata.FindNavigation(nameof(Tournament.Tours));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            tournamentConfiguration.Property(trn => trn.StartDate).HasColumnType("DateTime2");
            tournamentConfiguration.Property(trn => trn.EndDate).HasColumnType("DateTime2");
        }
    }
}