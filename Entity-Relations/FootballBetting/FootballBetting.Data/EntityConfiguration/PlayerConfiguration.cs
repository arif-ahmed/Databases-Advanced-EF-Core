using FootballBetting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.EntityConfiguration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(player => player.PlayerId);

            builder.HasOne(player => player.Team).WithMany(team => team.Players).HasForeignKey(player => player.TeamId);

            builder.HasOne(player => player.Position)
                .WithMany(position => position.Players)
                .HasForeignKey(player => player.PositionId);

            builder.HasMany(player => player.PlayerStatistics)
                .WithOne(playerStatistic => playerStatistic.Player)
                .HasForeignKey(player => player.PlayerId);
        }
    }
}