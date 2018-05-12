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
            builder.HasOne(team => team.SecondaryKitColor)
                .WithMany(color => color.SecondaryKitTeams)
                .HasForeignKey(c => c.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(team => team.Town);

            builder.HasMany(team => team.HomeGames).WithOne(game => game.HomeTeam)
                .HasForeignKey(game => game.HomeTeamId);

            builder.HasMany(team => team.AwayGames).WithOne(game => game.AwayTeam)
                .HasForeignKey(game => game.AwayTeamId);

            builder.HasMany(team => team.Players).WithOne(player => player.Team).HasForeignKey(player => player.TeamId);
        }
    }
}