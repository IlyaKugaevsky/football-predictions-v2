using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Predictions.Domain.Models;

namespace Predictions.Persistence.Configurations
{
    public class TeamEntityConfiguration: IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> predictionConfiguration)
        {
            predictionConfiguration.HasKey(t => t.Id);
            predictionConfiguration.Property(t => t.Id).HasColumnName("TeamId");
        }
    }
}