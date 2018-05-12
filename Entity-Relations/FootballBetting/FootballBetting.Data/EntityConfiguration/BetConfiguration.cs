using FootballBetting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.EntityConfiguration
{
    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(bet => bet.BetId);

            builder.Property(bet => bet.Prediction).IsRequired();

            builder.HasOne(bet => bet.Game).WithMany(game => game.Bets);
            builder.HasOne(bet => bet.User).WithMany(user => user.Bets).HasForeignKey(bet => bet.UserId);
        }
    }
}