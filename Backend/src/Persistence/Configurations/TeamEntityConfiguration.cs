using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TeamEntityConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> teamConfiguration)
        {
            teamConfiguration.HasKey(t => t.Id);
            teamConfiguration.Property(t => t.Id).HasColumnName("TeamId");
        }
    }
}