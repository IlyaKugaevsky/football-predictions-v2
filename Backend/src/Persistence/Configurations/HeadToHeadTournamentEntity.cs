using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class HeadToHeadTournamentEntityConfiguration: IEntityTypeConfiguration<HeadToHeadTournament>
    {
        public void Configure(EntityTypeBuilder<HeadToHeadTournament> headToHeadTournamentConfiguration)
        {
            headToHeadTournamentConfiguration.HasKey(tnm => tnm.Id);

            headToHeadTournamentConfiguration.Property(tnm => tnm.Id).HasColumnName("HeadToHeadTournamentId");

            var navigation
                = headToHeadTournamentConfiguration.Metadata.FindNavigation(nameof(HeadToHeadTournament.Tours));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}