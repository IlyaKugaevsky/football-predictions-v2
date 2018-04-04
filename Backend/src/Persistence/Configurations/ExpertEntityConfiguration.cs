using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ExpertEntityConfiguration : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> expertConfiguration)
        {
            expertConfiguration.HasKey(e => e.Id);
            expertConfiguration.Property(e => e.Id).HasColumnName("ExpertId");

            var navigation
                = expertConfiguration.Metadata.FindNavigation(nameof(Expert.Predictions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}