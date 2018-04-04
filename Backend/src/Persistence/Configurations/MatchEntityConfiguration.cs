using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MatchEntityConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> matchConfiguration)
        {
            matchConfiguration.HasKey(m => m.Id);
            matchConfiguration.Property(m => m.Id).HasColumnName("MatchId");

            matchConfiguration
                .HasOne(m => m.Tour)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.TourId);

            matchConfiguration
                .OwnsOne(m => m.Score)
                .Property(s => s.Value)
                .HasColumnName("Score");

            // matchConfiguration
            //     .HasOne(m => m.HomeTeam)
            //     .WithOne()
            //     .HasForeignKey(m => m.HomeTeamId);

            // matchConfiguration.HasForeignKey(m => m.HomeTeamId);
            // matchConfiguration.HasForeignKey(m => m.AwayTeamId);

            // matchConfiguration
            //     .HasForeignKey(m => m.AwayTeamId);

            matchConfiguration.Property(m => m.Date).HasColumnType("DateTime2");

            var navigation
                = matchConfiguration.Metadata.FindNavigation(nameof(Match.Predictions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}