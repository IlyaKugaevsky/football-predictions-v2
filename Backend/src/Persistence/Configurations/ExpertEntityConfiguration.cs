using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Predictions.Domain.Models;

namespace Predictions.Persistence.Configurations
{
    public class ExpertEntityConfiguration: IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> predictionConfiguration)
        {
            predictionConfiguration.HasKey(e => e.Id);
            predictionConfiguration.Property(e => e.Id).HasColumnName("ExpertId");
        }
    }
}