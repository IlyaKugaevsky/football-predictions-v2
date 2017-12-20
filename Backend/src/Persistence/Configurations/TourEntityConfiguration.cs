using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Predictions.Domain.Models;

namespace Predictions.Persistence.Configurations
{
    public class TourEntityConfiguration: IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> matchConfiguration)
        {
            matchConfiguration
                .HasOne(t => t.Tournament)
                .WithMany(trn => trn.Tours)
                .HasForeignKey(m => m.TournamentId);   
        }
        
    }
}