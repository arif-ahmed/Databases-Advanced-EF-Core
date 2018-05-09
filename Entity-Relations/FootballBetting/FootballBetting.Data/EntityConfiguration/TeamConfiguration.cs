using FootballBetting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.EntityConfiguration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(team => team.TeamId);

            builder.HasOne(team => team.PrimaryKitColor).WithMany(color => color.PrimaryKitTeams).HasForeignKey(c => c.PrimaryKitColorId);
            builder.HasOne(team => team.SecondaryKitColor).WithMany(color => color.SecondaryKitTeams).HasForeignKey(c => c.SecondaryKitColorId);
        }
    }
}