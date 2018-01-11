using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PredictionEntityConfiguration : IEntityTypeConfiguration<Prediction>
    {
        public void Configure(EntityTypeBuilder<Prediction> predictionConfiguration)
        {
            predictionConfiguration.HasKey(p => p.Id);
            predictionConfiguration.Property(p => p.Id).HasColumnName("PredictionId");

            predictionConfiguration
                .HasOne(p => p.Match)
                .WithMany(m => m.Predictions)
                .HasForeignKey(p => p.MatchId);

            predictionConfiguration
                .HasOne(p => p.Expert)
                .WithMany(e => e.Predictions)
                .HasForeignKey(p => p.ExpertId);
        }
    }
}