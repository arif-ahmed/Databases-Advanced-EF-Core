using FootballBetting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.EntityConfiguration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.GameId);

            builder.HasOne(x => x.HomeTeam).WithMany(x => x.HomeGames).HasForeignKey(x => x.HomeTeamId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.AwayTeam).WithMany(x => x.AwayGames).HasForeignKey(x => x.AwayTeamId);

            builder.HasMany(game => game.PlayerStatistics)
                .WithOne(playerStatistics => playerStatistics.Game)
                .HasForeignKey(game => game.GameId);

            builder.HasMany(game => game.Bets).WithOne(bet => bet.Game).HasForeignKey(game => game.BetId);
        }
    }
}