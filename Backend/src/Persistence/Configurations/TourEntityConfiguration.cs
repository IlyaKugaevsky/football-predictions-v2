using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TourEntityConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> tourConfiguration)
        {
            tourConfiguration.HasKey(t => t.Id);
            tourConfiguration.Property(t => t.Id).HasColumnName("TourId");

            tourConfiguration.Property(t => t.Number).HasColumnName("TourNumber");

            tourConfiguration.Property(t => t.StartDate).HasColumnType("DateTime2");
            tourConfiguration.Property(t => t.EndDate).HasColumnType("DateTime2");

            tourConfiguration
                .HasOne(t => t.Tournament)
                .WithMany(tnm => tnm.Tours)
                .HasForeignKey(m => m.TournamentId);

            var navigation
                = tourConfiguration.Metadata.FindNavigation(nameof(Tour.Matches));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}