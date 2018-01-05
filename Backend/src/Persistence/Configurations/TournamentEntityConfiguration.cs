using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Predictions.Domain.Models;

namespace Predictions.Persistence.Configurations
{
    public class TournamentEntityConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> tournamentConfiguration)
        {
            tournamentConfiguration.HasKey(tnm => tnm.Id);

            tournamentConfiguration.Property(tnm => tnm.Id).HasColumnName("TournamentId");

            tournamentConfiguration.Property(tnm => tnm.StartDate).HasColumnType("DateTime2");
            tournamentConfiguration.Property(tnm => tnm.EndDate).HasColumnType("DateTime2");

            var navigation 
                = tournamentConfiguration.Metadata.FindNavigation(nameof(Tournament.Tours));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}