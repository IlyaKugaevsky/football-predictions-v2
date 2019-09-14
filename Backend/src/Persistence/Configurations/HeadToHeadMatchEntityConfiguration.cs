using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class HeadToHeadMatchEntityConfiguration: IEntityTypeConfiguration<HeadToHeadMatch>
    {
        public void Configure(EntityTypeBuilder<HeadToHeadMatch> headToHeadMatchConfiguration)
        {
            headToHeadMatchConfiguration.HasKey(m => m.Id);
            headToHeadMatchConfiguration.Property(m => m.Id).HasColumnName("HeadToHeadMatchId");
            
            headToHeadMatchConfiguration
                .HasOne(m => m.HeadToHeadTour)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.HeadToHeadTourId);
        }
    }
}