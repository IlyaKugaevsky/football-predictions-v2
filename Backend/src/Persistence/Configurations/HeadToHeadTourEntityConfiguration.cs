using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class HeadToHeadTourEntityConfiguration: IEntityTypeConfiguration<HeadToHeadTour>
    {
        public void Configure(EntityTypeBuilder<HeadToHeadTour> headToHeadTourConfiguration)
        {
            headToHeadTourConfiguration.HasKey(t => t.Id);
            headToHeadTourConfiguration.Property(t => t.Id).HasColumnName("HeadToHeadTourId");

//            headToHeadTourConfiguration.Property(t => t.Number).HasColumnName("TourNumber");
//
//            headToHeadTourConfiguration.Property(t => t.StartDate).HasColumnType("DateTime2");
//            headToHeadTourConfiguration.Property(t => t.EndDate).HasColumnType("DateTime2");
//
//            headToHeadTourConfiguration
//                .HasOne(t => t.Tournament)
//                .WithMany(tnm => tnm.Tours)
//                .HasForeignKey(m => m.TournamentId);

            var navigation
                = headToHeadTourConfiguration.Metadata.FindNavigation(nameof(HeadToHeadTour.Matches));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}