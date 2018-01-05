using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Predictions.Domain.Models;

namespace Predictions.Persistence.Configurations
{
    public class FootballScoreEntityConfiguration: IEntityTypeConfiguration<FootballScore>
    {
        public void Configure(EntityTypeBuilder<FootballScore> scoreConfiguration)
        {
            scoreConfiguration.Property(s => s.ScoreValue).HasColumnName("Score");
        }
    }
}