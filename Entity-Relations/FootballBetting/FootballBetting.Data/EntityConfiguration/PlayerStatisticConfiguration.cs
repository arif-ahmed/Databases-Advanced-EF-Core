using FootballBetting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.EntityConfiguration
{
    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.HasKey(playerStatistic => new
            {
                playerStatistic.PlayerId,
                playerStatistic.GameId
            });

            builder.HasOne(playerStatistic => playerStatistic.Player)
                .WithMany(game => game.PlayerStatistics)
                .HasForeignKey(playerStatistic => playerStatistic.PlayerId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(playerStatistic => playerStatistic.Game)
                .WithMany(game => game.PlayerStatistics)
                .HasForeignKey(playerStatistic => playerStatistic.GameId);
        }
    }
}